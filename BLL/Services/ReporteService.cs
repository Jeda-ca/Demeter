using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReporteService : IReporteService
    {
        private readonly IReporteRepository _reporteRepository;
        private readonly ITipoReporteRepository _tipoReporteRepository;
        private readonly IVentaService _ventaService;
        private readonly IProductoService _productoService;
        private readonly IClienteService _clienteService;
        private readonly IVendedorService _vendedorService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAdministradorRepository _administradorRepository;

        public ReporteService()
        {
            _reporteRepository = new ReporteRepository();
            _tipoReporteRepository = new TipoReporteRepository();
            _usuarioRepository = new UsuarioRepository();
            _administradorRepository = new AdministradorRepository();

            _clienteService = new ClienteService();
            _productoService = new ProductoService();
            _ventaService = new VentaService();
            _vendedorService = new VendedorService();
        }

        public ReporteService(
            IReporteRepository reporteRepository, ITipoReporteRepository tipoReporteRepository,
            IVentaService ventaService, IProductoService productoService,
            IClienteService clienteService, IVendedorService vendedorService,
            IUsuarioRepository usuarioRepository, IAdministradorRepository administradorRepository) // Añadir
        {
            _reporteRepository = reporteRepository; _tipoReporteRepository = tipoReporteRepository;
            _ventaService = ventaService; _productoService = productoService;
            _clienteService = clienteService; _vendedorService = vendedorService;
            _usuarioRepository = usuarioRepository;
            _administradorRepository = administradorRepository; // Asignar
        }

        private bool ValidarAdministrador(int idUsuarioAdmin, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (idUsuarioAdmin <= 0) { errorMessage = "ID de administrador (usuario) inválido."; return false; }
            var adminUser = _usuarioRepository.GetById(idUsuarioAdmin);
            if (adminUser == null || !(adminUser is Administrador) || !adminUser.Activo)
            {
                errorMessage = "Operación no permitida. Se requiere un administrador activo.";
                return false;
            }
            return true;
        }

        private void RegistrarMetadatoReporte(int idUsuarioAdmin, string tipoReporteNombre, int? filtroVendedorId = null, int? filtroClienteId = null, DateTime? periodoInicio = null, DateTime? periodoFin = null)
        {
            var tipoReporte = _tipoReporteRepository.GetByName(tipoReporteNombre);
            if (tipoReporte == null) { Console.WriteLine($"Advertencia BLL: Tipo de reporte '{tipoReporteNombre}' no encontrado en la BD. No se registrará la metadata."); return; }

            var adminEntity = _administradorRepository.GetByUsuarioId(idUsuarioAdmin);
            if (adminEntity == null)
            {
                Console.WriteLine($"Advertencia BLL: No se encontró la entidad Administrador para el Usuario ID: {idUsuarioAdmin}. No se registrará metadata de reporte.");
                return;
            }

            Reporte nuevoReporte = new Reporte
            {
                AdministradorId = adminEntity.IdAdministrador,
                TipoReporteId = tipoReporte.IdTipoReporte,
                FechaGeneracion = DateTime.Now,
                InicioPeriodo = periodoInicio,
                FinPeriodo = periodoFin,
                FiltroVendedorId = filtroVendedorId,
                FiltroClienteId = filtroClienteId
            };
            _reporteRepository.Add(nuevoReporte);
        }

        public IEnumerable<Venta> GenerarReporteVentasGeneralesPorFechas(int idUsuarioAdmin, DateTime fechaInicio, DateTime fechaFin, out string mensajeError)
        {
            if (!ValidarAdministrador(idUsuarioAdmin, out mensajeError)) return null;
            if (fechaInicio > fechaFin) { mensajeError = "La fecha de inicio no puede ser posterior a la fecha de fin."; return null; }
            try
            {
                var datos = _ventaService.ObtenerVentasPorRangoFechas(fechaInicio, fechaFin);
                RegistrarMetadatoReporte(idUsuarioAdmin, "VENTAS GENERALES", periodoInicio: fechaInicio, periodoFin: fechaFin);
                mensajeError = string.Empty;
                return datos;
            }
            catch (Exception ex) { mensajeError = $"Error al generar reporte de ventas generales por fechas: {ex.Message}"; return null; }
        }

        public IEnumerable<Venta> GenerarReporteVentasGenerales(int idUsuarioAdmin, out string mensajeError) { if (!ValidarAdministrador(idUsuarioAdmin, out mensajeError)) return null; var datos = _ventaService.ObtenerTodasLasVentasParaAdmin(); RegistrarMetadatoReporte(idUsuarioAdmin, "VENTAS GENERALES"); return datos; }
        public IEnumerable<Venta> GenerarReporteVentasPorVendedor(int idUsuarioAdmin, int idVendedor, out string mensajeError) { if (!ValidarAdministrador(idUsuarioAdmin, out mensajeError)) return null; if (idVendedor <= 0) { mensajeError = "ID de vendedor inválido."; return null; } var datos = _ventaService.ObtenerVentasPorVendedor(idVendedor); RegistrarMetadatoReporte(idUsuarioAdmin, "VENTAS POR VENDEDOR", filtroVendedorId: idVendedor); return datos; }
        public IEnumerable<Venta> GenerarReporteVentasPorVendedorYFechas(int idUsuarioAdmin, int idVendedor, DateTime fechaInicio, DateTime fechaFin, out string mensajeError) { if (!ValidarAdministrador(idUsuarioAdmin, out mensajeError)) return null; if (idVendedor <= 0) { mensajeError = "ID de vendedor inválido."; return null; } if (fechaInicio > fechaFin) { mensajeError = "Fecha de inicio no puede ser posterior a fecha fin."; return null; } var datos = _ventaService.ObtenerVentasPorVendedorYFechas(idVendedor, fechaInicio, fechaFin); RegistrarMetadatoReporte(idUsuarioAdmin, "VENTAS POR VENDEDOR", filtroVendedorId: idVendedor, periodoInicio: fechaInicio, periodoFin: fechaFin); return datos; }
        public IEnumerable<Producto> GenerarReporteInventarioGeneral(int idUsuarioAdmin, out string mensajeError) { if (!ValidarAdministrador(idUsuarioAdmin, out mensajeError)) return null; var datos = _productoService.ObtenerTodosLosProductos(); RegistrarMetadatoReporte(idUsuarioAdmin, "INVENTARIO GENERAL"); return datos; }
        public IEnumerable<Producto> GenerarReporteInventarioPorVendedor(int idUsuarioAdmin, int idVendedor, out string mensajeError) { if (!ValidarAdministrador(idUsuarioAdmin, out mensajeError)) return null; if (idVendedor <= 0) { mensajeError = "ID de vendedor inválido."; return null; } var datos = _productoService.ObtenerProductosPorVendedor(idVendedor); RegistrarMetadatoReporte(idUsuarioAdmin, "INVENTARIO POR VENDEDOR", filtroVendedorId: idVendedor); return datos; }
        public IEnumerable<Reporte> ObtenerHistorialDeReportes(int idUsuarioAdmin, out string mensajeError) { if (!ValidarAdministrador(idUsuarioAdmin, out mensajeError)) return null; mensajeError = string.Empty; return _reporteRepository.GetAll(); }

        public DashboardAdminResumenVentas ObtenerResumenVentasDashboard(int idUsuarioAdmin, DateTime fechaInicio, DateTime fechaFin, out string mensajeError) { if (!ValidarAdministrador(idUsuarioAdmin, out mensajeError)) return null; try { var ventasEnPeriodo = _ventaService.ObtenerVentasPorRangoFechas(fechaInicio, fechaFin).Where(v => v.EstadoVenta?.Nombre.ToUpper() == "COMPLETADA").ToList(); return new DashboardAdminResumenVentas { NumeroDeVentas = ventasEnPeriodo.Count(), TotalGanancias = ventasEnPeriodo.Sum(v => v.Total) }; } catch (Exception ex) { mensajeError = $"Error al obtener resumen de ventas: {ex.Message}"; return null; } }
        public IEnumerable<DashboardAdminIngresoPorFecha> ObtenerIngresosPorFechaDashboard(int idUsuarioAdmin, DateTime fechaInicio, DateTime fechaFin, out string mensajeError) { if (!ValidarAdministrador(idUsuarioAdmin, out mensajeError)) return null; try { var ventasCompletadas = _ventaService.ObtenerVentasPorRangoFechas(fechaInicio, fechaFin).Where(v => v.EstadoVenta?.Nombre.ToUpper() == "COMPLETADA").ToList(); return ventasCompletadas.GroupBy(v => v.FechaOcurrencia.Date).Select(g => new DashboardAdminIngresoPorFecha { Fecha = g.Key, Ingreso = g.Sum(v => v.Total) }).OrderBy(r => r.Fecha).ToList(); } catch (Exception ex) { mensajeError = $"Error al obtener ingresos por fecha: {ex.Message}"; return null; } }
        public IEnumerable<DashboardAdminTopProducto> ObtenerTopProductosVendidosDashboard(int idUsuarioAdmin, DateTime fechaInicio, DateTime fechaFin, int topN, out string mensajeError) { if (!ValidarAdministrador(idUsuarioAdmin, out mensajeError)) return null; try { var ventasCompletadas = _ventaService.ObtenerVentasPorRangoFechas(fechaInicio, fechaFin).Where(v => v.EstadoVenta?.Nombre.ToUpper() == "COMPLETADA").ToList(); return ventasCompletadas.SelectMany(v => v.DetallesVenta).GroupBy(dv => dv.ProductoId).Select(g => new { ProductoId = g.Key, NombreProducto = g.First().Producto?.Nombre ?? _productoService.ObtenerProductoPorId(g.Key)?.Nombre ?? "Desconocido", CantidadVendida = g.Sum(dv => dv.Cantidad), ValorTotalVendido = g.Sum(dv => dv.TotalLinea) }).OrderByDescending(r => r.CantidadVendida).Take(topN).Select(r => new DashboardAdminTopProducto { NombreProducto = r.NombreProducto, CantidadVendida = r.CantidadVendida, ValorTotalVendido = r.ValorTotalVendido }).ToList(); } catch (Exception ex) { mensajeError = $"Error al obtener top productos: {ex.Message}"; return null; } }
        public DashboardAdminContadores ObtenerContadoresGeneralesDashboard(int idUsuarioAdmin, out string mensajeError) { if (!ValidarAdministrador(idUsuarioAdmin, out mensajeError)) return null; try { return new DashboardAdminContadores { TotalClientesActivos = _clienteService.ObtenerTodosLosClientes().Count(c => c.Activo), TotalVendedoresActivos = _vendedorService.ObtenerTodosLosVendedores().Count(v => v.Activo), TotalProductosActivos = _productoService.ObtenerTodosLosProductos().Count(p => p.Activo) }; } catch (Exception ex) { mensajeError = $"Error al obtener contadores generales: {ex.Message}"; return null; } }
        public IEnumerable<Producto> ObtenerProductosConBajoStockDashboard(int idUsuarioAdmin, int umbralStock, out string mensajeError) { if (!ValidarAdministrador(idUsuarioAdmin, out mensajeError)) return null; try { return _productoService.ObtenerTodosLosProductos().Where(p => p.Activo && p.Stock < umbralStock).OrderBy(p => p.Stock).ToList(); } catch (Exception ex) { mensajeError = $"Error al obtener productos con bajo stock: {ex.Message}"; return null; } }

    }
}
