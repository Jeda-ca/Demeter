using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IReporteService
    {
        IEnumerable<Venta> GenerarReporteVentasGenerales(int idAdministrador, out string mensajeError);
        IEnumerable<Venta> GenerarReporteVentasGeneralesPorFechas(int idAdministrador, DateTime fechaInicio, DateTime fechaFin, out string mensajeError);
        IEnumerable<Venta> GenerarReporteVentasPorVendedor(int idAdministrador, int idVendedor, out string mensajeError);
        IEnumerable<Venta> GenerarReporteVentasPorVendedorYFechas(int idAdministrador, int idVendedor, DateTime fechaInicio, DateTime fechaFin, out string mensajeError);
        IEnumerable<Producto> GenerarReporteInventarioGeneral(int idAdministrador, out string mensajeError);
        IEnumerable<Producto> GenerarReporteInventarioPorVendedor(int idAdministrador, int idVendedor, out string mensajeError);
        // IEnumerable<Vendedor> GenerarReporteListadoVendedores(int idAdministrador, DateTime fechaInicio, DateTime fechaFin, out string mensajeError); // Ya se usa VendedorService directamente
        // IEnumerable<Cliente> GenerarReporteListadoClientes(int idAdministrador, DateTime fechaInicio, DateTime fechaFin, out string mensajeError); // Ya se usa ClienteService directamente
        IEnumerable<Reporte> ObtenerHistorialDeReportes(int idAdministrador, out string mensajeError);


        DashboardAdminResumenVentas ObtenerResumenVentasDashboard(int idAdministrador, DateTime fechaInicio, DateTime fechaFin, out string mensajeError);
        IEnumerable<DashboardAdminIngresoPorFecha> ObtenerIngresosPorFechaDashboard(int idAdministrador, DateTime fechaInicio, DateTime fechaFin, out string mensajeError);
        IEnumerable<DashboardAdminTopProducto> ObtenerTopProductosVendidosDashboard(int idAdministrador, DateTime fechaInicio, DateTime fechaFin, int topN, out string mensajeError);
        DashboardAdminContadores ObtenerContadoresGeneralesDashboard(int idAdministrador, out string mensajeError);
        IEnumerable<Producto> ObtenerProductosConBajoStockDashboard(int idAdministrador, int umbralStock, out string mensajeError);
    }

    // Clases DTO para los datos del Dashboard
    public class DashboardAdminResumenVentas
    {
        public int NumeroDeVentas { get; set; }
        public decimal TotalGanancias { get; set; }
    }

    public class DashboardAdminIngresoPorFecha
    {
        public DateTime Fecha { get; set; }
        public decimal Ingreso { get; set; }
    }

    public class DashboardAdminTopProducto
    {
        public string NombreProducto { get; set; }
        public int CantidadVendida { get; set; }
        public decimal ValorTotalVendido { get; set; }
    }
    public class DashboardAdminContadores
    {
        public int TotalClientesActivos { get; set; }
        public int TotalVendedoresActivos { get; set; }
        public int TotalProductosActivos { get; set; }
    }
}
