using DAL.Helpers;
using DAL.Interfaces;
using DAL.Repositories;
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
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuario GetById(int idUsuario)
        {
            Usuario usuario = null;
            string rolNombre = null;

            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string queryUsuarioRol = "SELECT r.name FROM users u INNER JOIN roles r ON u.role_id = r.id_role WHERE u.id_user = @IdUser;";
                using (SqlCommand cmdRol = new SqlCommand(queryUsuarioRol, connection))
                {
                    cmdRol.Parameters.AddWithValue("@IdUser", idUsuario);
                    connection.Open();
                    var resultRol = cmdRol.ExecuteScalar();
                    if (resultRol != null && resultRol != DBNull.Value)
                    {
                        rolNombre = resultRol.ToString();
                    }
                }

                if (string.IsNullOrEmpty(rolNombre))
                {
                    if (connection.State == ConnectionState.Open) connection.Close(); // Asegurar cierre si no se encontró rol
                    return null;
                }

                // Reutilizar la conexión si sigue abierta, o permitir que los repositorios la manejen
                // Para este ejemplo, los repositorios de Admin/Vendedor abrirán su propia conexión.
                // Esto es menos eficiente pero más simple si no se pasa la conexión/transacción.
                if (connection.State == ConnectionState.Open) connection.Close();


                if (rolNombre.ToUpper() == "ADMIN")
                {
                    var adminRepo = new AdministradorRepository();
                    usuario = adminRepo.GetByUsuarioId(idUsuario);
                }
                else if (rolNombre.ToUpper() == "SELLER")
                {
                    var vendedorRepo = new VendedorRepository();
                    usuario = vendedorRepo.GetByUsuarioId(idUsuario);
                }
            }
            return usuario;
        }

        public Usuario GetByNombreUsuario(string nombreUsuario)
        {
            int userId = 0;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string queryId = "SELECT id_user FROM users WHERE username = @Username";
                using (SqlCommand cmdId = new SqlCommand(queryId, connection))
                {
                    cmdId.Parameters.AddWithValue("@Username", nombreUsuario);
                    connection.Open();
                    var resultId = cmdId.ExecuteScalar();
                    if (resultId != null && resultId != DBNull.Value)
                    {
                        userId = Convert.ToInt32(resultId);
                    }
                }
            }
            return userId > 0 ? GetById(userId) : null;
        }

        public IEnumerable<Usuario> GetAllSystemUsers()
        {
            var usuarios = new List<Usuario>();
            var adminRepo = new AdministradorRepository();
            var vendedorRepo = new VendedorRepository();

            usuarios.AddRange(adminRepo.GetAll());
            usuarios.AddRange(vendedorRepo.GetAll());

            return usuarios.OrderBy(u => u.NombreUsuario).ToList();
        }

        public bool UpdateUsuarioBasico(int idUsuario, string nuevoNombreUsuario, string nuevoHashContrasena)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                List<string> setClauses = new List<string>();
                SqlCommand command = new SqlCommand();

                if (!string.IsNullOrWhiteSpace(nuevoNombreUsuario))
                {
                    setClauses.Add("username = @Username");
                    command.Parameters.AddWithValue("@Username", nuevoNombreUsuario);
                }
                if (!string.IsNullOrWhiteSpace(nuevoHashContrasena))
                {
                    setClauses.Add("password_hash = @PasswordHash");
                    command.Parameters.AddWithValue("@PasswordHash", nuevoHashContrasena);
                }

                if (!setClauses.Any()) return false;

                command.CommandText = $"UPDATE users SET {string.Join(", ", setClauses)} WHERE id_user = @IdUser";
                command.Parameters.AddWithValue("@IdUser", idUsuario);
                command.Connection = connection;

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}

