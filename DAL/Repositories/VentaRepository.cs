using DAL.Interfaces;
using DAL.Helpers;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Repositories
{
    public class VentaRepository : IVentaRepository
    {
        private const int ID_ESTADO_VENTA_PENDIENTE = 1;
        private const int ID_ESTADO_VENTA_COMPLETADA = 2;
        private const int ID_ESTADO_VENTA_CANCELADA = 3;


        private readonly IProductoRepository _productoRepository;

        public VentaRepository(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
        }
        public VentaRepository() : this(new ProductoRepository()) { }


        public Venta Add(Venta entity)
        {
            throw new NotImplementedException("Utilice AddVentaCompleta para registrar ventas con sus detalles y actualizar stock.");
        }

        public bool Update(Venta entity)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = @"UPDATE sales SET 
                                    status_id = @StatusId, 
                                    observations = @Observations 
                                 WHERE id_sale = @IdSale;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StatusId", entity.EstadoId);
                    command.Parameters.AddWithValue("@Observations", (object)entity.Observaciones ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IdSale", entity.IdVenta);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException("Las ventas no deben eliminarse físicamente. Utilice CancelarVenta para cambiar su estado y revertir el stock.");
        }

        public Venta GetById(int idVenta)
        {
            Venta venta = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT * FROM v_sales_summary WHERE id_sale = @IdSale;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdSale", idVenta);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            venta = MapFromView(reader);
                        }
                    }
                }
            }
            if (venta != null)
            {
                venta.DetallesVenta = GetDetallesParaVenta(venta.IdVenta, null);
            }
            return venta;
        }

        public IEnumerable<Venta> GetAll()
        {
            var ventas = new List<Venta>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                connection.Open();
                string queryVentas = "SELECT * FROM v_sales_summary ORDER BY occurrence_date DESC;";
                using (SqlCommand commandVentas = new SqlCommand(queryVentas, connection))
                {
                    using (SqlDataReader readerVentas = commandVentas.ExecuteReader())
                    {
                        while (readerVentas.Read())
                        {
                            ventas.Add(MapFromView(readerVentas));
                        }
                    }
                }

                foreach (var venta in ventas)
                {
                    venta.DetallesVenta = GetDetallesParaVenta(venta.IdVenta, connection);
                }
            }
            return ventas;
        }

        public IEnumerable<Venta> GetByClienteId(int clienteId)
        {
            var ventas = new List<Venta>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                connection.Open();
                string queryVentas = "SELECT * FROM v_sales_summary WHERE client_id = @ClientId ORDER BY occurrence_date DESC;";
                using (SqlCommand commandVentas = new SqlCommand(queryVentas, connection))
                {
                    commandVentas.Parameters.AddWithValue("@ClientId", clienteId);
                    using (SqlDataReader readerVentas = commandVentas.ExecuteReader())
                    {
                        while (readerVentas.Read())
                        {
                            ventas.Add(MapFromView(readerVentas));
                        }
                    }
                }
                foreach (var venta in ventas)
                {
                    venta.DetallesVenta = GetDetallesParaVenta(venta.IdVenta, connection);
                }
            }
            return ventas;
        }
        public IEnumerable<Venta> GetByVendedorId(int vendedorId)
        {
            var ventas = new List<Venta>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                connection.Open();
                string queryVentas = "SELECT * FROM v_sales_summary WHERE seller_id = @SellerId ORDER BY occurrence_date DESC;";
                using (SqlCommand commandVentas = new SqlCommand(queryVentas, connection))
                {
                    commandVentas.Parameters.AddWithValue("@SellerId", vendedorId);
                    using (SqlDataReader readerVentas = commandVentas.ExecuteReader())
                    {
                        while (readerVentas.Read())
                        {
                            ventas.Add(MapFromView(readerVentas));
                        }
                    }
                }
                foreach (var venta in ventas)
                {
                    venta.DetallesVenta = GetDetallesParaVenta(venta.IdVenta, connection);
                }
            }
            return ventas;
        }
        public IEnumerable<Venta> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            var ventas = new List<Venta>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                connection.Open();
                string queryVentas = "SELECT * FROM v_sales_summary WHERE occurrence_date BETWEEN @StartDate AND @EndDate ORDER BY occurrence_date DESC;";
                using (SqlCommand commandVentas = new SqlCommand(queryVentas, connection))
                {
                    commandVentas.Parameters.AddWithValue("@StartDate", startDate);
                    commandVentas.Parameters.AddWithValue("@EndDate", endDate.Date.AddDays(1).AddTicks(-1));
                    using (SqlDataReader readerVentas = commandVentas.ExecuteReader())
                    {
                        while (readerVentas.Read())
                        {
                            ventas.Add(MapFromView(readerVentas));
                        }
                    }
                }
                foreach (var venta in ventas)
                {
                    venta.DetallesVenta = GetDetallesParaVenta(venta.IdVenta, connection);
                }
            }
            return ventas;
        }
        public IEnumerable<Venta> GetByVendedorAndDateRange(int vendedorId, DateTime startDate, DateTime endDate)
        {
            var ventas = new List<Venta>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                connection.Open();
                string queryVentas = "SELECT * FROM v_sales_summary WHERE seller_id = @SellerId AND occurrence_date BETWEEN @StartDate AND @EndDate ORDER BY occurrence_date DESC;";
                using (SqlCommand commandVentas = new SqlCommand(queryVentas, connection))
                {
                    commandVentas.Parameters.AddWithValue("@SellerId", vendedorId);
                    commandVentas.Parameters.AddWithValue("@StartDate", startDate);
                    commandVentas.Parameters.AddWithValue("@EndDate", endDate.Date.AddDays(1).AddTicks(-1));
                    using (SqlDataReader readerVentas = commandVentas.ExecuteReader())
                    {
                        while (readerVentas.Read())
                        {
                            ventas.Add(MapFromView(readerVentas));
                        }
                    }
                }
                foreach (var venta in ventas)
                {
                    venta.DetallesVenta = GetDetallesParaVenta(venta.IdVenta, connection);
                }
            }
            return ventas;
        }

        public Venta AddVentaCompleta(Venta venta)
        {
            if (venta == null || venta.DetallesVenta == null || !venta.DetallesVenta.Any())
            {
                throw new ArgumentException("La venta y sus detalles no pueden estar vacíos para AddVentaCompleta.");
            }

            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string ventaQuery = @"
                            INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id)
                            OUTPUT INSERTED.id_sale, INSERTED.occurrence_date 
                            VALUES (@OccurrenceDate, @Subtotal, @DiscountAmount, @TotalAmount, @StatusId, @Observations, @ClientId, @SellerId);";

                        using (SqlCommand ventaCommand = new SqlCommand(ventaQuery, connection, transaction))
                        {
                            ventaCommand.Parameters.AddWithValue("@OccurrenceDate", venta.FechaOcurrencia == DateTime.MinValue ? DateTime.Now : venta.FechaOcurrencia);
                            ventaCommand.Parameters.AddWithValue("@Subtotal", venta.Subtotal);
                            ventaCommand.Parameters.AddWithValue("@DiscountAmount", venta.Descuento);
                            ventaCommand.Parameters.AddWithValue("@TotalAmount", venta.Total);
                            ventaCommand.Parameters.AddWithValue("@StatusId", venta.EstadoId == 0 ? ID_ESTADO_VENTA_PENDIENTE : venta.EstadoId);
                            ventaCommand.Parameters.AddWithValue("@Observations", (object)venta.Observaciones ?? DBNull.Value);
                            ventaCommand.Parameters.AddWithValue("@ClientId", venta.ClienteId);
                            ventaCommand.Parameters.AddWithValue("@SellerId", venta.VendedorId);

                            using (SqlDataReader reader = ventaCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    venta.IdVenta = Convert.ToInt32(reader["id_sale"]);
                                    venta.FechaOcurrencia = Convert.ToDateTime(reader["occurrence_date"]);
                                }
                                else
                                {
                                    transaction.Rollback();
                                    throw new DataException("Error al insertar la cabecera de la venta: No se pudo obtener el ID.");
                                }
                            }
                        }

                        foreach (var detalle in venta.DetallesVenta)
                        {
                            detalle.VentaId = venta.IdVenta;
                            string detalleQuery = @"
                                INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total)
                                OUTPUT INSERTED.id_sale_detail
                                VALUES (@SaleId, @ProductId, @Quantity, @UnitPrice, @LineTotal);";
                            using (SqlCommand detalleCommand = new SqlCommand(detalleQuery, connection, transaction))
                            {
                                detalleCommand.Parameters.AddWithValue("@SaleId", detalle.VentaId);
                                detalleCommand.Parameters.AddWithValue("@ProductId", detalle.ProductoId);
                                detalleCommand.Parameters.AddWithValue("@Quantity", detalle.Cantidad);
                                detalleCommand.Parameters.AddWithValue("@UnitPrice", detalle.PrecioUnitario);
                                detalleCommand.Parameters.AddWithValue("@LineTotal", detalle.TotalLinea);

                                var detalleId = detalleCommand.ExecuteScalar();
                                if (detalleId != null && detalleId != DBNull.Value)
                                {
                                    detalle.IdDetalleVenta = Convert.ToInt32(detalleId);
                                }
                                else
                                {
                                    transaction.Rollback();
                                    throw new DataException("Error al insertar un detalle de la venta: No se pudo obtener el ID.");
                                }
                            }

                            string stockQuery = @"
                                UPDATE products 
                                SET stock_quantity = stock_quantity - @CantidadVendida, last_stock_update_date = GETDATE()
                                WHERE id_product = @ProductoId AND stock_quantity >= @CantidadVendida;";
                            using (SqlCommand stockCommand = new SqlCommand(stockQuery, connection, transaction))
                            {
                                stockCommand.Parameters.AddWithValue("@CantidadVendida", detalle.Cantidad);
                                stockCommand.Parameters.AddWithValue("@ProductoId", detalle.ProductoId);
                                int rowsAffected = stockCommand.ExecuteNonQuery();
                                if (rowsAffected == 0)
                                {
                                    transaction.Rollback();
                                    throw new InvalidOperationException($"Stock insuficiente para el producto ID {detalle.ProductoId} (Nombre: {detalle.Producto?.Nombre}) o producto no existe.");
                                }
                            }
                        }
                        transaction.Commit();
                        return venta;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool CancelarVenta(int idVenta, string motivoCancelacion)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        Venta ventaActual = null;
                        string selectVentaQuery = "SELECT * FROM v_sales_summary WHERE id_sale = @IdSale;"; // Usa la vista
                        using (SqlCommand cmdSelectVenta = new SqlCommand(selectVentaQuery, connection, transaction))
                        {
                            cmdSelectVenta.Parameters.AddWithValue("@IdSale", idVenta);
                            using (SqlDataReader reader = cmdSelectVenta.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    ventaActual = MapFromView(reader); // Usa el mapper de la vista
                                }
                            }
                        }

                        if (ventaActual == null)
                        {
                            transaction.Rollback();
                            return false;
                        }
                        if (ventaActual.EstadoId == ID_ESTADO_VENTA_CANCELADA)
                        {
                            transaction.Rollback();
                            return true;
                        }

                        var detallesParaRevertir = GetDetallesParaVenta(idVenta, connection, transaction);

                        string updateVentaQuery = @"
                            UPDATE sales SET 
                                status_id = @StatusId, 
                                observations = ISNULL(observations + CHAR(13)+CHAR(10), '') + @MotivoCancelacion
                            WHERE id_sale = @IdSale";
                        using (SqlCommand cmdUpdateVenta = new SqlCommand(updateVentaQuery, connection, transaction))
                        {
                            cmdUpdateVenta.Parameters.AddWithValue("@StatusId", ID_ESTADO_VENTA_CANCELADA);
                            cmdUpdateVenta.Parameters.AddWithValue("@MotivoCancelacion", $"Cancelada: {motivoCancelacion}");
                            cmdUpdateVenta.Parameters.AddWithValue("@IdSale", idVenta);

                            int rowsAffectedVenta = cmdUpdateVenta.ExecuteNonQuery();
                            if (rowsAffectedVenta == 0)
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }

                        foreach (var detalle in detallesParaRevertir)
                        {
                            string stockQuery = @"
                                UPDATE products 
                                SET stock_quantity = stock_quantity + @CantidadRevertida, 
                                    last_stock_update_date = GETDATE()
                                WHERE id_product = @ProductoId;";
                            using (SqlCommand stockCommand = new SqlCommand(stockQuery, connection, transaction))
                            {
                                stockCommand.Parameters.AddWithValue("@CantidadRevertida", detalle.Cantidad);
                                stockCommand.Parameters.AddWithValue("@ProductoId", detalle.ProductoId);
                                stockCommand.ExecuteNonQuery();
                            }
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

        private ICollection<DetalleVenta> GetDetallesParaVenta(int ventaId, SqlConnection existingConnection, SqlTransaction existingTransaction = null)
        {
            var detalles = new List<DetalleVenta>();
            SqlConnection connection = existingConnection;
            bool manageConnectionLocally = false;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = ConnectionHelper.GetConnection();
                connection.Open();
                manageConnectionLocally = true;
            }

            string queryDetalles = "SELECT * FROM v_sale_line_items_enriched WHERE sale_id = @SaleId;";
            using (SqlCommand commandDetalles = new SqlCommand(queryDetalles, connection))
            {
                if (existingTransaction != null && connection == existingTransaction.Connection)
                    commandDetalles.Transaction = existingTransaction;

                commandDetalles.Parameters.AddWithValue("@SaleId", ventaId);

                using (SqlDataReader readerDetalles = commandDetalles.ExecuteReader())
                {
                    while (readerDetalles.Read())
                    {
                        detalles.Add(MapToDetalleVentaFromView(readerDetalles));
                    }
                }
            }
            if (manageConnectionLocally && connection.State == ConnectionState.Open) connection.Close();
            return detalles;
        }

        private Venta MapFromView(SqlDataReader reader)
        {
            return new Venta
            {
                IdVenta = Convert.ToInt32(reader["id_sale"]),
                FechaOcurrencia = Convert.ToDateTime(reader["occurrence_date"]),
                Subtotal = Convert.ToDecimal(reader["subtotal"]),
                Descuento = Convert.ToDecimal(reader["discount_amount"]),
                Total = Convert.ToDecimal(reader["total_amount"]),
                EstadoId = Convert.ToInt32(reader["status_id"]),
                Observaciones = reader["observations"] == DBNull.Value ? null : reader["observations"].ToString(),
                ClienteId = Convert.ToInt32(reader["client_id"]),
                VendedorId = Convert.ToInt32(reader["seller_id"]),
                EstadoVenta = new EstadoVenta
                {
                    IdEstado = Convert.ToInt32(reader["status_id"]),
                    Nombre = reader["sale_status_name"].ToString()
                },
                Cliente = new Cliente
                {
                    IdCliente = Convert.ToInt32(reader["client_id"]),
                    CodigoCliente = reader["client_code"].ToString(),
                    IdPersona = Convert.ToInt32(reader["client_person_id"]),
                    Nombre = reader["client_first_name"].ToString(),
                    Apellido = reader["client_last_name"].ToString()
                },
                Vendedor = new Vendedor
                {
                    IdVendedor = Convert.ToInt32(reader["seller_id"]),
                    CodigoVendedor = reader["seller_code"].ToString(),
                    IdUsuario = Convert.ToInt32(reader["seller_user_id"]),
                    IdPersona = Convert.ToInt32(reader["seller_person_id"]),
                    Nombre = reader["seller_first_name"].ToString(),
                    Apellido = reader["seller_last_name"].ToString()
                },
                DetallesVenta = new List<DetalleVenta>()
            };
        }
        private DetalleVenta MapToDetalleVentaFromView(SqlDataReader reader)
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
                    Precio = Convert.ToDecimal(reader["product_current_price"]),
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
