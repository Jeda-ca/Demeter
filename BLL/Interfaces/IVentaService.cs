using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IVentaService
    {
        string RegistrarNuevaVenta(Venta venta, int idVendedorLogueado);

        // Para Frm_Admin_GVentas, Frm_Admin_VentasxVendedor, Frm_Admin_InformeVCompleto, Frm_Vendor_Ventas
        IEnumerable<Venta> ObtenerVentasPorVendedor(int idVendedor);
        IEnumerable<Venta> ObtenerVentasPorCliente(int idCliente);
        IEnumerable<Venta> ObtenerVentasPorRangoFechas(DateTime inicio, DateTime fin);
        IEnumerable<Venta> ObtenerVentasPorVendedorYFechas(int idVendedor, DateTime inicio, DateTime fin);
        IEnumerable<Venta> ObtenerTodasLasVentasParaAdmin();
        Venta ObtenerVentaPorId(int idVenta);
        string CancelarVenta(int idVenta, string motivo);
    }
}
