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
    public class ReporteRepository : IReporteRepository
    {
        public Reporte Add(Reporte entity)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = @"
                    INSERT INTO reports (administrator_id, generation_date, report_type_id, period_start_date, period_end_date, filter_seller_id, filter_client_id)
                    OUTPUT INSERTED.id_report, INSERTED.generation_date
                    VALUES (@AdministratorId, @GenerationDate, @ReportTypeId, @PeriodStartDate, @PeriodEndDate, @FilterSellerId, @FilterClientId);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AdministratorId", entity.AdministradorId);
                    command.Parameters.AddWithValue("@GenerationDate", entity.FechaGeneracion == DateTime.MinValue ? DateTime.Now : entity.FechaGeneracion);
                    command.Parameters.AddWithValue("@ReportTypeId", entity.TipoReporteId);
                    command.Parameters.AddWithValue("@PeriodStartDate", (object)entity.InicioPeriodo ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PeriodEndDate", (object)entity.FinPeriodo ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FilterSellerId", (object)entity.FiltroVendedorId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FilterClientId", (object)entity.FiltroClienteId ?? DBNull.Value);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity.IdReporte = Convert.ToInt32(reader["id_report"]);
                            entity.FechaGeneracion = Convert.ToDateTime(reader["generation_date"]);
                        }
                        else
                        {
                            throw new DataException("Error al agregar el reporte: No se pudo obtener el ID.");
                        }
                    }
                }
            }
            return entity;
        }

        public bool Update(Reporte entity) { throw new NotImplementedException("Los metadatos de reportes generados no suelen actualizarse."); }
        public bool Delete(int id) { throw new NotImplementedException("Los metadatos de reportes generados no suelen eliminarse."); }

        public Reporte GetById(int id)
        {
            Reporte entity = null;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT * FROM v_report_metadata_details WHERE id_report = @IdReport;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdReport", id);
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
        public IEnumerable<Reporte> GetAll()
        {
            var list = new List<Reporte>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT * FROM v_report_metadata_details ORDER BY generation_date DESC;";
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
        public IEnumerable<Reporte> GetByTipoReporte(int tipoReporteId)
        {
            var list = new List<Reporte>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT * FROM v_report_metadata_details WHERE report_type_id = @ReportTypeId ORDER BY generation_date DESC;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ReportTypeId", tipoReporteId);
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
        public IEnumerable<Reporte> GetByAdministradorAndDateRange(int administradorId, DateTime startDate, DateTime endDate)
        {
            var list = new List<Reporte>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT * FROM v_report_metadata_details WHERE administrator_id = @AdministratorId AND generation_date BETWEEN @StartDate AND @EndDate ORDER BY generation_date DESC;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AdministratorId", administradorId);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate.Date.AddDays(1).AddTicks(-1));
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

        private Reporte MapFromView(SqlDataReader reader)
        {
            var reporte = new Reporte
            {
                IdReporte = Convert.ToInt32(reader["id_report"]),
                AdministradorId = Convert.ToInt32(reader["administrator_id"]),
                FechaGeneracion = Convert.ToDateTime(reader["generation_date"]),
                TipoReporteId = Convert.ToInt32(reader["report_type_id"]),
                InicioPeriodo = reader["period_start_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["period_start_date"]),
                FinPeriodo = reader["period_end_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["period_end_date"]),
                FiltroVendedorId = reader["filter_seller_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["filter_seller_id"]),
                FiltroClienteId = reader["filter_client_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["filter_client_id"]),

                TipoReporte = new TipoReporte
                {
                    IdTipoReporte = Convert.ToInt32(reader["report_type_id"]),
                    Nombre = reader["report_type_name"].ToString()
                },
                Administrador = new Administrador // Parcialmente poblado desde la vista
                {
                    IdAdministrador = Convert.ToInt32(reader["administrator_id"]),
                    Nombre = reader["admin_first_name"].ToString(),
                    Apellido = reader["admin_last_name"].ToString()
                }
            };

            if (reporte.FiltroVendedorId.HasValue && reader["filter_seller_code"] != DBNull.Value)
            {
                reporte.VendedorFiltrado = new Vendedor
                {
                    IdVendedor = reporte.FiltroVendedorId.Value,
                    CodigoVendedor = reader["filter_seller_code"].ToString(),
                    Nombre = reader["filter_seller_first_name"].ToString(),
                    Apellido = reader["filter_seller_last_name"].ToString()
                };
            }
            if (reporte.FiltroClienteId.HasValue && reader["filter_client_code"] != DBNull.Value)
            {
                reporte.ClienteFiltrado = new Cliente
                {
                    IdCliente = reporte.FiltroClienteId.Value,
                    CodigoCliente = reader["filter_client_code"].ToString(),
                    Nombre = reader["filter_client_first_name"].ToString(),
                    Apellido = reader["filter_client_last_name"].ToString()
                };
            }
            return reporte;
        }
    }
}
