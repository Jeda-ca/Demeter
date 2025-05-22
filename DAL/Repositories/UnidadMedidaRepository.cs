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
    public class UnidadMedidaRepository : IUnidadMedidaRepository
    {
        public UnidadMedida Add(UnidadMedida entity)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "INSERT INTO measurement_units (name) OUTPUT INSERTED.id_measurement_unit VALUES (@Name);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", entity.Nombre);
                    connection.Open();
                    var newId = command.ExecuteScalar();
                    if (newId != null && newId != DBNull.Value)
                    {
                        entity.IdUnidadMedida = Convert.ToInt32(newId);
                        return entity;
                    }
                    else
                    {
                        throw new DataException("Error al agregar la unidad de medida: No se pudo obtener el nuevo ID.");
                    }
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string checkQuery = "SELECT COUNT(*) FROM products WHERE measurement_unit_id = @IdMeasurementUnit";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@IdMeasurementUnit", id);
                    connection.Open();
                    if ((int)checkCommand.ExecuteScalar() > 0)
                    {
                        connection.Close();
                        return false; // En uso, no se puede eliminar
                    }
                    connection.Close();
                }

                string query = "DELETE FROM measurement_units WHERE id_measurement_unit = @IdMeasurementUnit";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMeasurementUnit", id);
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public IEnumerable<UnidadMedida> GetAll()
        {
            var list = new List<UnidadMedida>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT id_measurement_unit, name FROM measurement_units ORDER BY name";
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

        public UnidadMedida GetById(int id)
        {
            UnidadMedida entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT id_measurement_unit, name FROM measurement_units WHERE id_measurement_unit = @IdMeasurementUnit";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMeasurementUnit", id);
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

        public bool Update(UnidadMedida entity)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "UPDATE measurement_units SET name = @Name WHERE id_measurement_unit = @IdMeasurementUnit";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", entity.Nombre);
                    command.Parameters.AddWithValue("@IdMeasurementUnit", entity.IdUnidadMedida);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public UnidadMedida GetByName(string name)
        {
            UnidadMedida entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT id_measurement_unit, name FROM measurement_units WHERE name = @Name";
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

        private UnidadMedida MapToEntity(SqlDataReader reader)
        {
            return new UnidadMedida
            {
                IdUnidadMedida = Convert.ToInt32(reader["id_measurement_unit"]),
                Nombre = reader["name"].ToString()
            };
        }
    }
}
