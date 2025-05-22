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
    public class ClienteRepository : IClienteRepository
    {
        public Cliente Add(Cliente entity)
        {
            if (entity == null || string.IsNullOrWhiteSpace(entity.Nombre) ||
                string.IsNullOrWhiteSpace(entity.Apellido) || entity.TipoDocumentoId == 0 ||
                string.IsNullOrWhiteSpace(entity.NumeroDocumento) || string.IsNullOrWhiteSpace(entity.CodigoCliente))
            {
                throw new ArgumentException("Los datos básicos de persona y código de cliente son requeridos.");
            }

            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar en persons
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
                                else
                                {
                                    transaction.Rollback();
                                    throw new DataException("Error al insertar en persons para el nuevo Cliente.");
                                }
                            }
                        }

                        // 2. Insertar en clients
                        string clienteQuery = @"
                            INSERT INTO clients (person_id, client_code, last_purchase_date, email, is_active)
                            OUTPUT INSERTED.id_client
                            VALUES (@PersonId, @ClientCode, @LastPurchaseDate, @Email, @IsActive);";

                        using (SqlCommand clienteCommand = new SqlCommand(clienteQuery, connection, transaction))
                        {
                            clienteCommand.Parameters.AddWithValue("@PersonId", entity.IdPersona);
                            clienteCommand.Parameters.AddWithValue("@ClientCode", entity.CodigoCliente);
                            clienteCommand.Parameters.AddWithValue("@LastPurchaseDate", (object)entity.UltimaCompra ?? DBNull.Value);
                            clienteCommand.Parameters.AddWithValue("@Email", (object)entity.Correo ?? DBNull.Value);
                            clienteCommand.Parameters.AddWithValue("@IsActive", entity.Activo);

                            var newClienteId = clienteCommand.ExecuteScalar();
                            if (newClienteId != null && newClienteId != DBNull.Value)
                            {
                                entity.IdCliente = Convert.ToInt32(newClienteId);
                            }
                            else
                            {
                                transaction.Rollback();
                                throw new DataException("Error al insertar en clients.");
                            }
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

        public bool Update(Cliente entity)
        {
            if (entity == null || entity.IdCliente == 0 || entity.IdPersona == 0)
            {
                throw new ArgumentException("ID de Cliente y Persona son requeridos para la actualización.");
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

                        string clienteQuery = @"
                            UPDATE clients SET 
                                client_code = @ClientCode, last_purchase_date = @LastPurchaseDate, 
                                email = @Email, is_active = @IsActive
                            WHERE id_client = @IdClient AND person_id = @IdPerson;";
                        using (SqlCommand clienteCommand = new SqlCommand(clienteQuery, connection, transaction))
                        {
                            clienteCommand.Parameters.AddWithValue("@ClientCode", entity.CodigoCliente);
                            clienteCommand.Parameters.AddWithValue("@LastPurchaseDate", (object)entity.UltimaCompra ?? DBNull.Value);
                            clienteCommand.Parameters.AddWithValue("@Email", (object)entity.Correo ?? DBNull.Value);
                            clienteCommand.Parameters.AddWithValue("@IsActive", entity.Activo);
                            clienteCommand.Parameters.AddWithValue("@IdClient", entity.IdCliente);
                            clienteCommand.Parameters.AddWithValue("@IdPerson", entity.IdPersona);

                            clienteCommand.ExecuteNonQuery();
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

        public bool Delete(int idCliente)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int personaIdToDelete = 0;
                        string getIdPersonaQuery = "SELECT person_id FROM clients WHERE id_client = @IdClient";
                        using (SqlCommand cmd = new SqlCommand(getIdPersonaQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdClient", idCliente);
                            var result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                personaIdToDelete = Convert.ToInt32(result);
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }

                        string checkVentasQuery = "SELECT COUNT(*) FROM sales WHERE client_id = @IdClient";
                        using (SqlCommand checkCmd = new SqlCommand(checkVentasQuery, connection, transaction))
                        {
                            checkCmd.Parameters.AddWithValue("@IdClient", idCliente);
                            if ((int)checkCmd.ExecuteScalar() > 0)
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }

                        string clienteQuery = "DELETE FROM clients WHERE id_client = @IdClient";
                        using (SqlCommand clienteCommand = new SqlCommand(clienteQuery, connection, transaction))
                        {
                            clienteCommand.Parameters.AddWithValue("@IdClient", idCliente);
                            clienteCommand.ExecuteNonQuery();
                        }

                        if (personaIdToDelete > 0)
                        {
                            string personaQuery = "DELETE FROM persons WHERE id_person = @IdPerson";
                            using (SqlCommand personaCommand = new SqlCommand(personaQuery, connection, transaction))
                            {
                                personaCommand.Parameters.AddWithValue("@IdPerson", personaIdToDelete);
                                personaCommand.ExecuteNonQuery();
                            }
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

        public Cliente GetById(int idCliente)
        {
            Cliente entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = GetBaseClienteSelectQuery() + " WHERE c.id_client = @IdClient;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdClient", idCliente);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity = MapToEntityWithJoins(reader);
                        }
                    }
                }
            }
            return entity;
        }

        public IEnumerable<Cliente> GetAll()
        {
            var list = new List<Cliente>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = GetBaseClienteSelectQuery() + " ORDER BY p.last_name, p.first_name;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapToEntityWithJoins(reader));
                        }
                    }
                }
            }
            return list;
        }

        public Cliente GetByCodigoCliente(string codigo)
        {
            Cliente entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = GetBaseClienteSelectQuery() + " WHERE c.client_code = @ClientCode;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientCode", codigo);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity = MapToEntityWithJoins(reader);
                        }
                    }
                }
            }
            return entity;
        }

        public IEnumerable<Cliente> SearchByNombreOApellido(string searchTerm)
        {
            var list = new List<Cliente>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = GetBaseClienteSelectQuery() +
                               " WHERE p.first_name LIKE @SearchTerm OR p.last_name LIKE @SearchTerm ORDER BY p.last_name, p.first_name;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapToEntityWithJoins(reader));
                        }
                    }
                }
            }
            return list;
        }

        public Cliente GetByNumeroDocumento(int tipoDocumentoId, string numeroDocumento)
        {
            Cliente entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = GetBaseClienteSelectQuery() +
                               " WHERE p.document_type_id = @DocumentTypeId AND p.document_number = @DocumentNumber;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DocumentTypeId", tipoDocumentoId);
                    command.Parameters.AddWithValue("@DocumentNumber", numeroDocumento);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity = MapToEntityWithJoins(reader);
                        }
                    }
                }
            }
            return entity;
        }

        private string GetBaseClienteSelectQuery()
        {
            return @"
                SELECT 
                    c.id_client, c.client_code, c.last_purchase_date, c.email, c.is_active,
                    p.id_person, p.first_name, p.last_name, p.document_type_id, 
                    p.document_number, p.registration_date, p.phone_number,
                    dt.name AS document_type_name
                FROM clients c
                INNER JOIN persons p ON c.person_id = p.id_person
                INNER JOIN document_types dt ON p.document_type_id = dt.id_document_type";
        }

        private Cliente MapToEntityWithJoins(SqlDataReader reader)
        {
            var cliente = new Cliente
            {
                IdPersona = Convert.ToInt32(reader["id_person"]),
                Nombre = reader["first_name"].ToString(),
                Apellido = reader["last_name"].ToString(),
                TipoDocumentoId = Convert.ToInt32(reader["document_type_id"]),
                NumeroDocumento = reader["document_number"].ToString(),
                FechaRegistro = Convert.ToDateTime(reader["registration_date"]),
                Telefono = reader["phone_number"] == DBNull.Value ? null : reader["phone_number"].ToString(),
                TipoDocumento = new TipoDocumento
                {
                    IdTipoDocumento = Convert.ToInt32(reader["document_type_id"]),
                    Nombre = reader["document_type_name"].ToString()
                },
                IdCliente = Convert.ToInt32(reader["id_client"]),
                CodigoCliente = reader["client_code"].ToString(),
                UltimaCompra = reader["last_purchase_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["last_purchase_date"]),
                Correo = reader["email"] == DBNull.Value ? null : reader["email"].ToString(),
                Activo = Convert.ToBoolean(reader["is_active"])
            };
            return cliente;
        }
    }
}
