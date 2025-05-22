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
        IEnumerable<Venta> GenerarReporteVentasPorVendedor(int idAdministrador, int idVendedor, out string mensajeError);
        IEnumerable<Venta> GenerarReporteVentasGeneralesPorFechas(int idAdministrador, DateTime fechaInicio, DateTime fechaFin, out string mensajeError);
        IEnumerable<Venta> GenerarReporteVentasPorVendedorYFechas(int idAdministrador, int idVendedor, DateTime fechaInicio, DateTime fechaFin, out string mensajeError);
        IEnumerable<Producto> GenerarReporteInventarioGeneral(int idAdministrador, out string mensajeError);
        IEnumerable<Producto> GenerarReporteInventarioPorVendedor(int idAdministrador, int idVendedor, out string mensajeError);
        IEnumerable<Cliente> GenerarReporteListadoClientes(int idAdministrador, out string mensajeError);
        IEnumerable<Reporte> ObtenerHistorialDeReportes(int idAdministrador, out string mensajeError);
    }
}
