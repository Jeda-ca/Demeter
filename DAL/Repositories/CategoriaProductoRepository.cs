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
    public class CategoriaProductoRepository : ICategoriaProductoRepository
    {
        public CategoriaProducto Add(CategoriaProducto entity)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "INSERT INTO product_categories (name) OUTPUT INSERTED.id_category VALUES (@Name);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", entity.Nombre);
                    connection.Open();
                    var newId = command.ExecuteScalar();
                    if (newId != null && newId != DBNull.Value)
                    {
                        entity.IdCategoria = Convert.ToInt32(newId);
                        return entity;
                    }
                    else
                    {
                        throw new DataException("Error al agregar la categoría de producto: No se pudo obtener el nuevo ID.");
                    }
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string checkQuery = "SELECT COUNT(*) FROM products WHERE category_id = @IdCategory";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@IdCategory", id);
                    connection.Open();
                    if ((int)checkCommand.ExecuteScalar() > 0)
                    {
                        connection.Close();
                        return false;
                    }
                    connection.Close();
                }

                string query = "DELETE FROM product_categories WHERE id_category = @IdCategory";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdCategory", id);
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public IEnumerable<CategoriaProducto> GetAll()
        {
            var list = new List<CategoriaProducto>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT id_category, name FROM product_categories ORDER BY name";
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

        public CategoriaProducto GetById(int id)
        {
            CategoriaProducto entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT id_category, name FROM product_categories WHERE id_category = @IdCategory";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdCategory", id);
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

        public bool Update(CategoriaProducto entity)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "UPDATE product_categories SET name = @Name WHERE id_category = @IdCategory";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", entity.Nombre);
                    command.Parameters.AddWithValue("@IdCategory", entity.IdCategoria);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public CategoriaProducto GetByName(string name)
        {
            CategoriaProducto entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT id_category, name FROM product_categories WHERE name = @Name";
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

        private CategoriaProducto MapToEntity(SqlDataReader reader)
        {
            return new CategoriaProducto
            {
                IdCategoria = Convert.ToInt32(reader["id_category"]),
                Nombre = reader["name"].ToString()
            };
        }
    }
}
