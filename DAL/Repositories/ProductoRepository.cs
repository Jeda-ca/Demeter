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
    public class ProductoRepository : IProductoRepository
    {
        public Producto Add(Producto entity)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = @"
                    INSERT INTO products 
                        (name, description, price, measurement_unit_id, category_id, stock_quantity, 
                         creation_date, last_stock_update_date, seller_id, is_active)
                    OUTPUT INSERTED.id_product, INSERTED.creation_date, INSERTED.last_stock_update_date
                    VALUES 
                        (@Name, @Description, @Price, @MeasurementUnitId, @CategoryId, @StockQuantity, 
                         @CreationDate, @LastStockUpdateDate, @SellerId, @IsActive);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", entity.Nombre);
                    command.Parameters.AddWithValue("@Description", (object)entity.Descripcion ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Price", entity.Precio);
                    command.Parameters.AddWithValue("@MeasurementUnitId", entity.UnidadMedidaId);
                    command.Parameters.AddWithValue("@CategoryId", entity.CategoriaId);
                    command.Parameters.AddWithValue("@StockQuantity", entity.Stock);
                    command.Parameters.AddWithValue("@CreationDate", entity.FechaCreacion == DateTime.MinValue ? DateTime.Now : entity.FechaCreacion);
                    command.Parameters.AddWithValue("@LastStockUpdateDate", entity.FechaActualizacionStock == DateTime.MinValue ? DateTime.Now : entity.FechaActualizacionStock);
                    command.Parameters.AddWithValue("@SellerId", entity.VendedorId);
                    command.Parameters.AddWithValue("@IsActive", entity.Activo);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity.IdProducto = Convert.ToInt32(reader["id_product"]);
                            entity.FechaCreacion = Convert.ToDateTime(reader["creation_date"]);
                            entity.FechaActualizacionStock = Convert.ToDateTime(reader["last_stock_update_date"]);
                        }
                        else
                        {
                            throw new DataException("Error al agregar el producto: No se pudo obtener el ID y fechas generadas.");
                        }
                    }
                }
            }
            return entity;
        }

        public bool Update(Producto entity)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = @"
                    UPDATE products SET 
                        name = @Name, 
                        description = @Description, 
                        price = @Price, 
                        measurement_unit_id = @MeasurementUnitId, 
                        category_id = @CategoryId, 
                        stock_quantity = @StockQuantity, 
                        last_stock_update_date = @LastStockUpdateDate, 
                        seller_id = @SellerId, 
                        is_active = @IsActive
                    WHERE id_product = @IdProduct;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", entity.Nombre);
                    command.Parameters.AddWithValue("@Description", (object)entity.Descripcion ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Price", entity.Precio);
                    command.Parameters.AddWithValue("@MeasurementUnitId", entity.UnidadMedidaId);
                    command.Parameters.AddWithValue("@CategoryId", entity.CategoriaId);
                    command.Parameters.AddWithValue("@StockQuantity", entity.Stock);
                    command.Parameters.AddWithValue("@LastStockUpdateDate", DateTime.Now);
                    command.Parameters.AddWithValue("@SellerId", entity.VendedorId);
                    command.Parameters.AddWithValue("@IsActive", entity.Activo);
                    command.Parameters.AddWithValue("@IdProduct", entity.IdProducto);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "DELETE FROM products WHERE id_product = @IdProduct";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdProduct", id);
                    connection.Open();
                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex) when (ex.Number == 547)
                    {
                        return false;
                    }
                }
            }
        }

        public Producto GetById(int id)
        {
            Producto entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT * FROM v_product_details WHERE id_product = @IdProduct;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdProduct", id);
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

        public IEnumerable<Producto> GetAll()
        {
            var list = new List<Producto>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT * FROM v_product_details ORDER BY product_name_alias;"; // Usar alias de la vista
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

        public IEnumerable<Producto> GetByVendedorId(int vendedorId)
        {
            var list = new List<Producto>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                // Consulta simplificada usando la vista
                string query = "SELECT * FROM v_product_details WHERE seller_id = @SellerId ORDER BY product_name_alias;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SellerId", vendedorId);
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
        public IEnumerable<Producto> GetByCategoriaId(int categoriaId)
        {
            var list = new List<Producto>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                // Consulta simplificada usando la vista
                string query = "SELECT * FROM v_product_details WHERE category_id = @CategoryId ORDER BY product_name_alias;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoriaId);
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

        public IEnumerable<Producto> SearchByNameAndVendedor(string partialName, int vendedorId)
        {
            var list = new List<Producto>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT * FROM v_product_details WHERE product_name_alias LIKE @PartialName AND seller_id = @SellerId ORDER BY product_name_alias;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PartialName", "%" + partialName + "%");
                    command.Parameters.AddWithValue("@SellerId", vendedorId);
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

        public bool RegistrarVentaStock(int productoId, int cantidadVendida)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = @"
                    UPDATE products 
                    SET stock_quantity = stock_quantity - @CantidadVendida,
                        last_stock_update_date = GETDATE()
                    WHERE id_product = @ProductoId AND stock_quantity >= @CantidadVendida;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CantidadVendida", cantidadVendida);
                    command.Parameters.AddWithValue("@ProductoId", productoId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public bool IncrementarStock(int productoId, int cantidadAgregada)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = @"
                    UPDATE products 
                    SET stock_quantity = stock_quantity + @CantidadAgregada,
                        last_stock_update_date = GETDATE()
                    WHERE id_product = @ProductoId;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CantidadAgregada", cantidadAgregada);
                    command.Parameters.AddWithValue("@ProductoId", productoId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool AjustarStockPorMerma(int productoId, int cantidadADecrementar, string motivoAjuste)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = @"
                    UPDATE products 
                    SET stock_quantity = stock_quantity - @CantidadADecrementar,
                        last_stock_update_date = GETDATE()
                    WHERE id_product = @ProductoId AND stock_quantity >= @CantidadADecrementar;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CantidadADecrementar", cantidadADecrementar);
                    command.Parameters.AddWithValue("@ProductoId", productoId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private Producto MapFromView(SqlDataReader reader)
        {
            var producto = new Producto
            {
                IdProducto = Convert.ToInt32(reader["id_product"]),
                Nombre = reader["product_name_alias"].ToString(),
                Descripcion = reader["product_description_alias"] == DBNull.Value ? null : reader["product_description_alias"].ToString(),
                Precio = Convert.ToDecimal(reader["product_price_alias"]),
                Stock = Convert.ToInt32(reader["stock_quantity"]),
                Activo = Convert.ToBoolean(reader["product_is_active_alias"]),
                FechaCreacion = Convert.ToDateTime(reader["product_creation_date_alias"]),
                FechaActualizacionStock = Convert.ToDateTime(reader["product_last_stock_update_date_alias"]),
                UnidadMedidaId = Convert.ToInt32(reader["measurement_unit_id"]),
                CategoriaId = Convert.ToInt32(reader["category_id"]),
                VendedorId = Convert.ToInt32(reader["seller_id"]),

                UnidadMedida = new UnidadMedida
                {
                    IdUnidadMedida = Convert.ToInt32(reader["measurement_unit_id"]),
                    Nombre = reader["measurement_unit_name"].ToString()
                },
                Categoria = new CategoriaProducto
                {
                    IdCategoria = Convert.ToInt32(reader["category_id"]),
                    Nombre = reader["category_name"].ToString()
                },
                Vendedor = new Vendedor
                {
                    IdVendedor = Convert.ToInt32(reader["seller_id"]),
                    CodigoVendedor = reader["seller_code"].ToString(),
                    IdUsuario = Convert.ToInt32(reader["seller_user_id"]),
                    NombreUsuario = reader["seller_username"].ToString(),
                    RolId = Convert.ToInt32(reader["seller_role_id"]),
                    Rol = new Rol
                    {
                        IdRol = Convert.ToInt32(reader["seller_role_id"]),
                        Nombre = reader["seller_role_name"].ToString()
                    },
                    IdPersona = Convert.ToInt32(reader["seller_person_id"]),
                    Nombre = reader["seller_first_name"].ToString(),
                    Apellido = reader["seller_last_name"].ToString(),
                    TipoDocumentoId = Convert.ToInt32(reader["seller_document_type_id"]),
                    TipoDocumento = new TipoDocumento
                    {
                        IdTipoDocumento = Convert.ToInt32(reader["seller_document_type_id"]),
                        Nombre = reader["seller_document_type_name"].ToString()
                    },
                    NumeroDocumento = reader["seller_document_number"].ToString(),
                    FechaRegistro = Convert.ToDateTime(reader["seller_person_registration_date"]),
                    Telefono = reader["seller_phone_number"] == DBNull.Value ? null : reader["seller_phone_number"].ToString()
                }
            };
            return producto;
        }
    }
}
