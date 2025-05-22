using BLL.Interfaces;
using DAL.Interfaces;
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
        private readonly IUsuarioRepository _usuarioRepository; // Para validar admin

        public ReporteService(
            IReporteRepository reporteRepository,
            ITipoReporteRepository tipoReporteRepository,
            IVentaService ventaService,
            IProductoService productoService,
            IClienteService clienteService,
            IUsuarioRepository usuarioRepository)
        {
            _reporteRepository = reporteRepository ?? throw new ArgumentNullException(nameof(reporteRepository));
            _tipoReporteRepository = tipoReporteRepository ?? throw new ArgumentNullException(nameof(tipoReporteRepository));
            _ventaService = ventaService ?? throw new ArgumentNullException(nameof(ventaService));
            _productoService = productoService ?? throw new ArgumentNullException(nameof(productoService));
            _clienteService = clienteService ?? throw new ArgumentNullException(nameof(clienteService));
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }

        private bool ValidarAdministrador(int idAdministrador, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (idAdministrador <= 0)
            {
                errorMessage = "ID de administrador inválido.";
                return false;
            }
            var admin = _usuarioRepository.GetById(idAdministrador);
            if (admin == null || !(admin is Administrador) || !admin.Activo)
            {
                errorMessage = "Operación no permitida. Se requiere un administrador activo.";
                return false;
            }
            return true;
        }

        private void RegistrarMetadatoReporte(int administradorId, string tipoReporteNombre, int? filtroVendedorId = null, int? filtroClienteId = null, DateTime? periodoInicio = null, DateTime? periodoFin = null)
        {
            var tipoReporte = _tipoReporteRepository.GetByName(tipoReporteNombre);
            if (tipoReporte == null)
            {

                Console.WriteLine($"Advertencia BLL: Tipo de reporte '{tipoReporteNombre}' no encontrado en la BD. No se registrará la metadata.");
                return;
            }

            Reporte nuevoReporte = new Reporte
            {
                AdministradorId = administradorId,
                TipoReporteId = tipoReporte.IdTipoReporte,
                FechaGeneracion = DateTime.Now, // Siempre la fecha actual
                InicioPeriodo = periodoInicio,
                FinPeriodo = periodoFin,
                FiltroVendedorId = filtroVendedorId,
                FiltroClienteId = filtroClienteId
            };
            _reporteRepository.Add(nuevoReporte);
        }

        // --- Métodos para generar los diferentes reportes ---

        public IEnumerable<Venta> GenerarReporteVentasGenerales(int idAdministrador, out string mensajeError)
        {
            if (!ValidarAdministrador(idAdministrador, out mensajeError))
            {
                return null;
            }
            try
            {
                var datos = _ventaService.ObtenerTodasLasVentasParaAdmin();
                RegistrarMetadatoReporte(idAdministrador, "VENTAS GENERALES");
                mensajeError = string.Empty;
                return datos;
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al generar reporte de ventas generales: {ex.Message}";
                return null;
            }
        }

        public IEnumerable<Venta> GenerarReporteVentasPorVendedor(int idAdministrador, int idVendedor, out string mensajeError)
        {
            if (!ValidarAdministrador(idAdministrador, out mensajeError))
            {
                return null;
            }
            if (idVendedor <= 0)
            {
                mensajeError = "ID de vendedor para el filtro es inválido.";
                return null;
            }
            try
            {
                var datos = _ventaService.ObtenerVentasPorVendedor(idVendedor);
                RegistrarMetadatoReporte(idAdministrador, "VENTAS POR VENDEDOR", filtroVendedorId: idVendedor);
                mensajeError = string.Empty;
                return datos;
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al generar reporte de ventas por vendedor: {ex.Message}";
                return null;
            }
        }

        public IEnumerable<Venta> GenerarReporteVentasGeneralesPorFechas(int idAdministrador, DateTime fechaInicio, DateTime fechaFin, out string mensajeError)
        {
            if (!ValidarAdministrador(idAdministrador, out mensajeError))
            {
                return null;
            }
            if (fechaInicio > fechaFin)
            {
                mensajeError = "La fecha de inicio no puede ser posterior a la fecha de fin.";
                return null;
            }
            try
            {
                var datos = _ventaService.ObtenerVentasPorRangoFechas(fechaInicio, fechaFin);
                RegistrarMetadatoReporte(idAdministrador, "VENTAS GENERALES", periodoInicio: fechaInicio, periodoFin: fechaFin);
                mensajeError = string.Empty;
                return datos;
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al generar reporte de ventas generales por fechas: {ex.Message}";
                return null;
            }
        }

        public IEnumerable<Venta> GenerarReporteVentasPorVendedorYFechas(int idAdministrador, int idVendedor, DateTime fechaInicio, DateTime fechaFin, out string mensajeError)
        {
            if (!ValidarAdministrador(idAdministrador, out mensajeError))
            {
                return null;
            }
            if (idVendedor <= 0)
            {
                mensajeError = "ID de vendedor para el filtro es inválido.";
                return null;
            }
            if (fechaInicio > fechaFin)
            {
                mensajeError = "La fecha de inicio no puede ser posterior a la fecha de fin.";
                return null;
            }
            try
            {
                var datos = _ventaService.ObtenerVentasPorVendedorYFechas(idVendedor, fechaInicio, fechaFin);
                RegistrarMetadatoReporte(idAdministrador, "VENTAS POR VENDEDOR", filtroVendedorId: idVendedor, periodoInicio: fechaInicio, periodoFin: fechaFin);
                mensajeError = string.Empty;
                return datos;
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al generar reporte de ventas por vendedor y fechas: {ex.Message}";
                return null;
            }
        }


        public IEnumerable<Producto> GenerarReporteInventarioGeneral(int idAdministrador, out string mensajeError)
        {
            if (!ValidarAdministrador(idAdministrador, out mensajeError))
            {
                return null;
            }
            try
            {
                // La GUI se encargará de mostrar solo los campos básicos.
                // Si se quisiera filtrar aquí, se podría hacer un Select(p => new { p.Nombre, p.Precio, p.Stock, ...})
                var datos = _productoService.ObtenerTodosLosProductos();
                RegistrarMetadatoReporte(idAdministrador, "INVENTARIO GENERAL");
                mensajeError = string.Empty;
                return datos;
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al generar reporte de inventario general: {ex.Message}";
                return null;
            }
        }

        public IEnumerable<Producto> GenerarReporteInventarioPorVendedor(int idAdministrador, int idVendedor, out string mensajeError)
        {
            if (!ValidarAdministrador(idAdministrador, out mensajeError))
            {
                return null;
            }
            if (idVendedor <= 0)
            {
                mensajeError = "ID de vendedor para el filtro es inválido.";
                return null;
            }
            try
            {
                var datos = _productoService.ObtenerProductosPorVendedor(idVendedor);
                RegistrarMetadatoReporte(idAdministrador, "INVENTARIO POR VENDEDOR", filtroVendedorId: idVendedor);
                mensajeError = string.Empty;
                return datos;
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al generar reporte de inventario por vendedor: {ex.Message}";
                return null;
            }
        }

        public IEnumerable<Cliente> GenerarReporteListadoClientes(int idAdministrador, out string mensajeError)
        {
            if (!ValidarAdministrador(idAdministrador, out mensajeError))
            {
                return null;
            }
            try
            {
                var datos = _clienteService.ObtenerTodosLosClientes();
                RegistrarMetadatoReporte(idAdministrador, "LISTA DE CLIENTES");
                mensajeError = string.Empty;
                return datos;
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al generar reporte de listado de clientes: {ex.Message}";
                return null;
            }
        }

        public IEnumerable<Reporte> ObtenerHistorialDeReportes(int idAdministrador, out string mensajeError)
        {
            if (!ValidarAdministrador(idAdministrador, out mensajeError))
            {
                return null;
            }
            try
            {
                var datos = _reporteRepository.GetAll();
                mensajeError = string.Empty;
                return datos;
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al obtener el historial de reportes: {ex.Message}";
                return null;
            }
        }
    }
}
