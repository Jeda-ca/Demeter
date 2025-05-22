using DAL.Helpers;
using DAL.Interfaces;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DetalleVentaRepository : IDetalleVentaRepository
    {
        // Los métodos Add, Update, Delete no cambian, ya que operan directamente sobre la tabla 'sale_details'.
        // Generalmente, los detalles de venta se gestionan a través de VentaRepository.AddVentaCompleta.
        public DetalleVenta Add(DetalleVenta entity) { throw new NotImplementedException("Los detalles de venta se agregan como parte de AddVentaCompleta en VentaRepository."); }
        public bool Update(DetalleVenta entity) { throw new NotImplementedException("Los detalles de venta no suelen actualizarse individualmente."); }
        public bool Delete(int id) { throw new NotImplementedException("Los detalles de venta no suelen eliminarse individualmente."); }

        public DetalleVenta GetById(int idSaleDetail)
        {
            DetalleVenta detalle = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                // Usa la vista para obtener la información enriquecida del producto
                string query = "SELECT * FROM v_sale_line_items_enriched WHERE id_sale_detail = @IdSaleDetail;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdSaleDetail", idSaleDetail);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            detalle = MapFromView(reader);
                        }
                    }
                }
            }
            return detalle;
        }
        public IEnumerable<DetalleVenta> GetAll() { throw new NotImplementedException("Obtener todos los detalles de todas las ventas no es una operación común y podría ser muy costosa."); }

        public IEnumerable<DetalleVenta> GetByVentaId(int ventaId)
        {
            var detalles = new List<DetalleVenta>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                // Usa la vista para obtener la información enriquecida del producto
                string queryDetalles = "SELECT * FROM v_sale_line_items_enriched WHERE sale_id = @SaleId;";
                using (SqlCommand commandDetalles = new SqlCommand(queryDetalles, connection))
                {
                    commandDetalles.Parameters.AddWithValue("@SaleId", ventaId);
                    connection.Open();
                    using (SqlDataReader readerDetalles = commandDetalles.ExecuteReader())
                    {
                        while (readerDetalles.Read())
                        {
                            detalles.Add(MapFromView(readerDetalles));
                        }
                    }
                }
            }
            return detalles;
        }

        // Nuevo método de Mapeo que lee desde la Vista 'v_sale_line_items_enriched'
        private DetalleVenta MapFromView(SqlDataReader reader)
        {
            return new DetalleVenta
            {
                IdDetalleVenta = Convert.ToInt32(reader["id_sale_detail"]),
                VentaId = Convert.ToInt32(reader["sale_id"]),
                ProductoId = Convert.ToInt32(reader["product_id"]),
                Cantidad = Convert.ToInt32(reader["quantity"]),
                PrecioUnitario = Convert.ToDecimal(reader["unit_price"]),
                TotalLinea = Convert.ToDecimal(reader["line_total"]),
                Producto = new Producto
                {
                    IdProducto = Convert.ToInt32(reader["product_id"]),
                    Nombre = reader["product_name"].ToString(),
                    Descripcion = reader["product_description"] == DBNull.Value ? null : reader["product_description"].ToString(),
                    Precio = Convert.ToDecimal(reader["product_current_price"]), // Precio actual del producto desde la vista
                    UnidadMedidaId = Convert.ToInt32(reader["product_measurement_unit_id"]),
                    UnidadMedida = new UnidadMedida
                    {
                        IdUnidadMedida = Convert.ToInt32(reader["product_measurement_unit_id"]),
                        Nombre = reader["product_measurement_unit_name"].ToString()
                    },
                    CategoriaId = Convert.ToInt32(reader["product_category_id"]),
                    Categoria = new CategoriaProducto
                    {
                        IdCategoria = Convert.ToInt32(reader["product_category_id"]),
                        Nombre = reader["product_category_name"].ToString()
                    }
                }
            };
        }
    }
}
