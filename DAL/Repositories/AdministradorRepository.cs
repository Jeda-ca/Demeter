using DAL.Helpers;
using DAL.Interfaces;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AdministradorRepository : IAdministradorRepository
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IUsuarioRepository _usuarioRepositoryInternal; // Usado para validaciones

        public AdministradorRepository()
        {
            _personaRepository = new PersonaRepository();
            _usuarioRepositoryInternal = new UsuarioRepository();
        }

        public Administrador Add(Administrador entity)
        {
            if (entity == null || string.IsNullOrWhiteSpace(entity.Nombre)
                || string.IsNullOrWhiteSpace(entity.Apellido) || entity.TipoDocumentoId == 0
                || string.IsNullOrWhiteSpace(entity.NumeroDocumento)
                || string.IsNullOrWhiteSpace(entity.NombreUsuario) || string.IsNullOrWhiteSpace(entity.HashContrasena)
                || entity.RolId == 0)
            {
                throw new ArgumentException("Datos incompletos para crear un administrador.");
            }

            if (_usuarioRepositoryInternal.GetByNombreUsuario(entity.NombreUsuario) != null)
            {
                throw new InvalidOperationException($"El nombre de usuario '{entity.NombreUsuario}' ya está en uso.");
            }
            if (_personaRepository.ExistePersonaPorDocumento(entity.TipoDocumentoId, entity.NumeroDocumento))
            {
                throw new InvalidOperationException($"Una persona con el documento tipo '{entity.TipoDocumentoId}' y número '{entity.NumeroDocumento}' ya existe.");
            }

            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string personaQuery = @"
                            INSERT INTO persons (first_name, last_name, document_type_id, document_number, registration_date, phone_number)
                            OUTPUT INSERTED.id_person, INSERTED.registration_date
                            VALUES (@FirstName, @LastName, @DocumentTypeId, @DocumentNumber, @RegistrationDate, @PhoneNumber);";

                        using (SqlCommand personaCommand = new SqlCommand(personaQuery, connection, transaction))
                        {
                            personaCommand.Parameters.AddWithValue("@FirstName", entity.Nombre);
                            personaCommand.Parameters.AddWithValue("@LastName", entity.Apellido);
                            personaCommand.Parameters.AddWithValue("@DocumentTypeId", entity.TipoDocumentoId);
                            personaCommand.Parameters.AddWithValue("@DocumentNumber", entity.NumeroDocumento);
                            personaCommand.Parameters.AddWithValue("@RegistrationDate", entity.FechaRegistro == DateTime.MinValue ? DateTime.Now : entity.FechaRegistro);
                            personaCommand.Parameters.AddWithValue("@PhoneNumber", (object)entity.Telefono ?? DBNull.Value);

                            using (SqlDataReader reader = personaCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    entity.IdPersona = Convert.ToInt32(reader["id_person"]);
                                    entity.FechaRegistro = Convert.ToDateTime(reader["registration_date"]);
                                }
                                else { transaction.Rollback(); throw new DataException("Error al insertar en persons para Administrador."); }
                            }
                        }

                        string usuarioQuery = @"
                            INSERT INTO users (person_id, username, password_hash, role_id) 
                            OUTPUT INSERTED.id_user, INSERTED.is_active
                            VALUES (@PersonId, @Username, @PasswordHash, @RoleId);";
                        using (SqlCommand usuarioCommand = new SqlCommand(usuarioQuery, connection, transaction))
                        {
                            usuarioCommand.Parameters.AddWithValue("@PersonId", entity.IdPersona);
                            usuarioCommand.Parameters.AddWithValue("@Username", entity.NombreUsuario);
                            usuarioCommand.Parameters.AddWithValue("@PasswordHash", entity.HashContrasena);
                            usuarioCommand.Parameters.AddWithValue("@RoleId", entity.RolId);

                            using (SqlDataReader reader = usuarioCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    entity.IdUsuario = Convert.ToInt32(reader["id_user"]);
                                    entity.Activo = Convert.ToBoolean(reader["is_active"]); // Asignar el estado activo
                                }
                                else { transaction.Rollback(); throw new DataException("Error al insertar en users para Administrador."); }
                            }
                        }

                        string adminQuery = @"
                            INSERT INTO administrators (user_id)
                            OUTPUT INSERTED.id_administrator
                            VALUES (@UserId);";
                        using (SqlCommand adminCommand = new SqlCommand(adminQuery, connection, transaction))
                        {
                            adminCommand.Parameters.AddWithValue("@UserId", entity.IdUsuario);
                            var newAdminId = adminCommand.ExecuteScalar();
                            if (newAdminId != null && newAdminId != DBNull.Value)
                            {
                                entity.IdAdministrador = Convert.ToInt32(newAdminId);
                            }
                            else { transaction.Rollback(); throw new DataException("Error al insertar en administrators."); }
                        }

                        transaction.Commit();
                        return entity;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool Update(Administrador entity)
        {
            if (entity == null || entity.IdAdministrador == 0 || entity.IdUsuario == 0 || entity.IdPersona == 0)
            {
                throw new ArgumentException("IDs son requeridos para la actualización de Administrador.");
            }
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string personaQuery = @"
                            UPDATE persons SET 
                                first_name = @FirstName, last_name = @LastName, document_type_id = @DocumentTypeId, 
                                document_number = @DocumentNumber, phone_number = @PhoneNumber
                            WHERE id_person = @IdPerson;";
                        using (SqlCommand personaCommand = new SqlCommand(personaQuery, connection, transaction))
                        {
                            personaCommand.Parameters.AddWithValue("@FirstName", entity.Nombre);
                            personaCommand.Parameters.AddWithValue("@LastName", entity.Apellido);
                            personaCommand.Parameters.AddWithValue("@DocumentTypeId", entity.TipoDocumentoId);
                            personaCommand.Parameters.AddWithValue("@DocumentNumber", entity.NumeroDocumento);
                            personaCommand.Parameters.AddWithValue("@PhoneNumber", (object)entity.Telefono ?? DBNull.Value);
                            personaCommand.Parameters.AddWithValue("@IdPerson", entity.IdPersona);
                            personaCommand.ExecuteNonQuery();
                        }

                        string usuarioQuery = @"
                            UPDATE users SET 
                                username = @Username, password_hash = @PasswordHash, role_id = @RoleId, is_active = @IsActive
                            WHERE id_user = @IdUser AND person_id = @IdPerson;";
                        using (SqlCommand usuarioCommand = new SqlCommand(usuarioQuery, connection, transaction))
                        {
                            usuarioCommand.Parameters.AddWithValue("@Username", entity.NombreUsuario);
                            usuarioCommand.Parameters.AddWithValue("@PasswordHash", entity.HashContrasena); 
                            usuarioCommand.Parameters.AddWithValue("@RoleId", entity.RolId);
                            usuarioCommand.Parameters.AddWithValue("@IsActive", entity.Activo); 
                            usuarioCommand.Parameters.AddWithValue("@IdUser", entity.IdUsuario);
                            usuarioCommand.Parameters.AddWithValue("@IdPerson", entity.IdPersona);
                            usuarioCommand.ExecuteNonQuery();
                        }


                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool Delete(int idAdministrador)
        {
           
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int userIdToInactivate = 0;

                        string getUserIdQuery = "SELECT user_id FROM administrators WHERE id_administrator = @IdAdministrator;";
                        using (SqlCommand cmdGetUserId = new SqlCommand(getUserIdQuery, connection, transaction))
                        {
                            cmdGetUserId.Parameters.AddWithValue("@IdAdministrator", idAdministrador);
                            var result = cmdGetUserId.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                userIdToInactivate = Convert.ToInt32(result);
                            }
                            else
                            {
                                transaction.Rollback(); // Administrador no encontrado
                                return false;
                            }
                        }

                        if (userIdToInactivate > 0)
                        {
                            // Inactivar el usuario
                            string updateUserQuery = "UPDATE users SET is_active = 0 WHERE id_user = @IdUser;";
                            using (SqlCommand cmdUpdateUser = new SqlCommand(updateUserQuery, connection, transaction))
                            {
                                cmdUpdateUser.Parameters.AddWithValue("@IdUser", userIdToInactivate);
                                int rowsAffected = cmdUpdateUser.ExecuteNonQuery();
                                if (rowsAffected == 0)
                                {
                                    transaction.Rollback(); // Usuario no encontrado o ya inactivo 
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            transaction.Rollback(); // No se encontró user_id para el admin
                            return false;
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (SqlException ex) when (ex.Number == 547) 
                    {
                        transaction.Rollback();

                        return false;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }


        public Administrador GetById(int idAdministrador)
        {
            Administrador entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT * FROM v_administrator_details WHERE id_administrator = @IdAdministrator;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdAdministrator", idAdministrador);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity = MapFromView(reader);
                        }
                    }
                }
            }
            return entity;
        }

        public IEnumerable<Administrador> GetAll()
        {
            var list = new List<Administrador>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT * FROM v_administrator_details ORDER BY person_last_name, person_first_name;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapFromView(reader));
                        }
                    }
                }
            }
            return list;
        }

        public Administrador GetByUsuarioId(int usuarioId)
        {
            Administrador entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT * FROM v_administrator_details WHERE id_user = @UserId;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", usuarioId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity = MapFromView(reader);
                        }
                    }
                }
            }
            return entity;
        }

        public IEnumerable<Administrador> SearchByNombreOApellido(string searchTerm)
        {
            var list = new List<Administrador>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT * FROM v_administrator_details WHERE (person_first_name LIKE @SearchTerm OR person_last_name LIKE @SearchTerm) ORDER BY person_last_name, person_first_name;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapFromView(reader));
                        }
                    }
                }
            }
            return list;
        }

        public Administrador GetByNumeroDocumento(int tipoDocumentoId, string numeroDocumento)
        {
            Administrador entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT * FROM v_administrator_details WHERE document_type_id = @DocumentTypeId AND document_number = @DocumentNumber;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DocumentTypeId", tipoDocumentoId);
                    command.Parameters.AddWithValue("@DocumentNumber", numeroDocumento);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity = MapFromView(reader);
                        }
                    }
                }
            }
            return entity;
        }

        private Administrador MapFromView(SqlDataReader reader)
        {
            var admin = new Administrador
            {
                IdPersona = Convert.ToInt32(reader["id_person"]),
                Nombre = reader["person_first_name"].ToString(),
                Apellido = reader["person_last_name"].ToString(),
                TipoDocumentoId = Convert.ToInt32(reader["document_type_id"]),
                NumeroDocumento = reader["document_number"].ToString(),
                FechaRegistro = Convert.ToDateTime(reader["person_registration_date"]),
                Telefono = reader["person_phone_number"] == DBNull.Value ? null : reader["person_phone_number"].ToString(),
                TipoDocumento = new TipoDocumento
                {
                    IdTipoDocumento = Convert.ToInt32(reader["document_type_id"]),
                    Nombre = reader["document_type_name"].ToString()
                },
                IdUsuario = Convert.ToInt32(reader["id_user"]),
                NombreUsuario = reader["username"].ToString(),
                HashContrasena = reader["password_hash"].ToString(),
                RolId = Convert.ToInt32(reader["role_id"]),
                Rol = new Rol
                {
                    IdRol = Convert.ToInt32(reader["role_id"]),
                    Nombre = reader["role_name"].ToString()
                },
                Activo = Convert.ToBoolean(reader["user_is_active"]),
                IdAdministrador = Convert.ToInt32(reader["id_administrator"])
            };
            return admin;
        }
    }
}
