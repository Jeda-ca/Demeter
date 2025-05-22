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
    public class EstadoVentaRepository : IEstadoVentaRepository
    {
        public EstadoVenta Add(EstadoVenta entity)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "INSERT INTO sale_statuses (name) OUTPUT INSERTED.id_status VALUES (@Name);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", entity.Nombre);
                    connection.Open();
                    var newId = command.ExecuteScalar();
                    if (newId != null && newId != DBNull.Value)
                    {
                        entity.IdEstado = Convert.ToInt32(newId);
                        return entity;
                    }
                    else
                    {
                        throw new DataException("Error al agregar el estado de venta: No se pudo obtener el nuevo ID.");
                    }
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string checkQuery = "SELECT COUNT(*) FROM sales WHERE status_id = @IdStatus";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@IdStatus", id);
                    connection.Open();
                    if ((int)checkCommand.ExecuteScalar() > 0)
                    {
                        connection.Close();
                        return false;
                    }
                    connection.Close();
                }

                string query = "DELETE FROM sale_statuses WHERE id_status = @IdStatus";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdStatus", id);
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public IEnumerable<EstadoVenta> GetAll()
        {
            var list = new List<EstadoVenta>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT id_status, name FROM sale_statuses ORDER BY name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapToEntity(reader));
                        }
                    }
                }
            }
            return list;
        }

        public EstadoVenta GetById(int id)
        {
            EstadoVenta entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT id_status, name FROM sale_statuses WHERE id_status = @IdStatus";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdStatus", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity = MapToEntity(reader);
                        }
                    }
                }
            }
            return entity;
        }

        public bool Update(EstadoVenta entity)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "UPDATE sale_statuses SET name = @Name WHERE id_status = @IdStatus";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", entity.Nombre);
                    command.Parameters.AddWithValue("@IdStatus", entity.IdEstado);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public EstadoVenta GetByName(string name)
        {
            EstadoVenta entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT id_status, name FROM sale_statuses WHERE name = @Name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity = MapToEntity(reader);
                        }
                    }
                }
            }
            return entity;
        }

        private EstadoVenta MapToEntity(SqlDataReader reader)
        {
            return new EstadoVenta
            {
                IdEstado = Convert.ToInt32(reader["id_status"]),
                Nombre = reader["name"].ToString()
            };
        }
    }
}
