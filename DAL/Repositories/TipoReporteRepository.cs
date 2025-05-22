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
    public class TipoReporteRepository : ITipoReporteRepository
    {
        public TipoReporte Add(TipoReporte entity)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "INSERT INTO report_types (name) OUTPUT INSERTED.id_report_type VALUES (@Name);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", entity.Nombre);
                    connection.Open();
                    var newId = command.ExecuteScalar();
                    if (newId != null && newId != DBNull.Value)
                    {
                        entity.IdTipoReporte = Convert.ToInt32(newId);
                        return entity;
                    }
                    else
                    {
                        throw new DataException("Error al agregar el tipo de reporte: No se pudo obtener el nuevo ID.");
                    }
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string checkQuery = "SELECT COUNT(*) FROM reports WHERE report_type_id = @IdReportType";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@IdReportType", id);
                    connection.Open();
                    if ((int)checkCommand.ExecuteScalar() > 0)
                    {
                        connection.Close();
                        return false;
                    }
                    connection.Close();
                }

                string query = "DELETE FROM report_types WHERE id_report_type = @IdReportType";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdReportType", id);
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public IEnumerable<TipoReporte> GetAll()
        {
            var list = new List<TipoReporte>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT id_report_type, name FROM report_types ORDER BY name";
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

        public TipoReporte GetById(int id)
        {
            TipoReporte entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT id_report_type, name FROM report_types WHERE id_report_type = @IdReportType";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdReportType", id);
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

        public bool Update(TipoReporte entity)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "UPDATE report_types SET name = @Name WHERE id_report_type = @IdReportType";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", entity.Nombre);
                    command.Parameters.AddWithValue("@IdReportType", entity.IdTipoReporte);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public TipoReporte GetByName(string name)
        {
            TipoReporte entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT id_report_type, name FROM report_types WHERE name = @Name";
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

        private TipoReporte MapToEntity(SqlDataReader reader)
        {
            return new TipoReporte
            {
                IdTipoReporte = Convert.ToInt32(reader["id_report_type"]),
                Nombre = reader["name"].ToString()
            };
        }
    }
}
