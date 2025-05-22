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
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        public TipoDocumento Add(TipoDocumento entity)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "INSERT INTO document_types (name) OUTPUT INSERTED.id_document_type VALUES (@Name);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", entity.Nombre);
                    connection.Open();
                    var newId = command.ExecuteScalar();
                    if (newId != null && newId != DBNull.Value)
                    {
                        entity.IdTipoDocumento = Convert.ToInt32(newId);
                        return entity;
                    }
                    else
                    {
                        throw new DataException("Error al agregar el tipo de documento: No se pudo obtener el nuevo ID.");
                    }
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string checkQuery = "SELECT COUNT(*) FROM persons WHERE document_type_id = @IdDocumentType";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@IdDocumentType", id);
                    connection.Open();
                    if ((int)checkCommand.ExecuteScalar() > 0)
                    {
                        connection.Close();
                        return false;
                    }
                    connection.Close();
                }

                string query = "DELETE FROM document_types WHERE id_document_type = @IdDocumentType";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdDocumentType", id);
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public IEnumerable<TipoDocumento> GetAll()
        {
            var list = new List<TipoDocumento>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT id_document_type, name FROM document_types ORDER BY name";
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

        public TipoDocumento GetById(int id)
        {
            TipoDocumento entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT id_document_type, name FROM document_types WHERE id_document_type = @IdDocumentType";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdDocumentType", id);
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

        public bool Update(TipoDocumento entity)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "UPDATE document_types SET name = @Name WHERE id_document_type = @IdDocumentType";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", entity.Nombre);
                    command.Parameters.AddWithValue("@IdDocumentType", entity.IdTipoDocumento);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public TipoDocumento GetByName(string name)
        {
            TipoDocumento entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT id_document_type, name FROM document_types WHERE name = @Name";
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

        private TipoDocumento MapToEntity(SqlDataReader reader)
        {
            return new TipoDocumento
            {
                IdTipoDocumento = Convert.ToInt32(reader["id_document_type"]),
                Nombre = reader["name"].ToString()
            };
        }
    }
}