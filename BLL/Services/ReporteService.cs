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
        private readonly IVentaService _ventaService; // ReporteService depende de otros servicios
        private readonly IProductoService _productoService;
        private readonly IClienteService _clienteService;
        private readonly IUsuarioRepository _usuarioRepository;


        public ReporteService()
        {
            _reporteRepository = new ReporteRepository();
            _tipoReporteRepository = new TipoReporteRepository();
            _usuarioRepository = new UsuarioRepository(); // Necesario para validar admin

            // Los otros servicios también deben tener constructores por defecto o ser instanciados aquí
            // Esto puede crear una cadena de dependencias si no se maneja con cuidado.
            // Para simplificar, asumimos que los servicios pueden ser instanciados así:
            _clienteService = new ClienteService(); // Asume constructor por defecto en ClienteService
            _productoService = new ProductoService(); // Asume constructor por defecto en ProductoService
            _ventaService = new VentaService(); // Asume constructor por defecto en VentaService
        }

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
        // ... (resto de los métodos de ReporteService sin cambios en su lógica interna) ...
        private bool ValidarAdministrador(int idAdministrador, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (idAdministrador <= 0)
            {
                errorMessage = "ID de administrador inválido.";
                return false;
            }
            var admin = _usuarioRepository.GetById(idAdministrador); // Usa el repo de usuario
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
                Console.WriteLine($"Advertencia BLL: Tipo de reporte '{tipoReporteNombre}' no encontrado. No se registrará metadata.");
                return;
            }
            Reporte nuevoReporte = new Reporte
            {
                AdministradorId = administradorId,
                TipoReporteId = tipoReporte.IdTipoReporte,
                FechaGeneracion = DateTime.Now,
                InicioPeriodo = periodoInicio,
                FinPeriodo = periodoFin,
                FiltroVendedorId = filtroVendedorId,
                FiltroClienteId = filtroClienteId
            };
            _reporteRepository.Add(nuevoReporte);
        }
        public IEnumerable<Venta> GenerarReporteVentasGenerales(int idAdministrador, out string mensajeError)
        {
            if (!ValidarAdministrador(idAdministrador, out mensajeError)) return null;
            var datos = _ventaService.ObtenerTodasLasVentasParaAdmin();
            RegistrarMetadatoReporte(idAdministrador, "VENTAS GENERALES");
            return datos;
        }
        public IEnumerable<Venta> GenerarReporteVentasPorVendedor(int idAdministrador, int idVendedor, out string mensajeError)
        {
            if (!ValidarAdministrador(idAdministrador, out mensajeError)) return null;
            if (idVendedor <= 0) { mensajeError = "ID de vendedor inválido."; return null; }
            var datos = _ventaService.ObtenerVentasPorVendedor(idVendedor);
            RegistrarMetadatoReporte(idAdministrador, "VENTAS POR VENDEDOR", filtroVendedorId: idVendedor);
            return datos;
        }
        public IEnumerable<Venta> GenerarReporteVentasGeneralesPorFechas(int idAdministrador, DateTime fechaInicio, DateTime fechaFin, out string mensajeError)
        {
            if (!ValidarAdministrador(idAdministrador, out mensajeError)) return null;
            if (fechaInicio > fechaFin) { mensajeError = "Fecha de inicio no puede ser posterior a fecha fin."; return null; }
            var datos = _ventaService.ObtenerVentasPorRangoFechas(fechaInicio, fechaFin);
            RegistrarMetadatoReporte(idAdministrador, "VENTAS GENERALES", periodoInicio: fechaInicio, periodoFin: fechaFin);
            return datos;
        }
        public IEnumerable<Venta> GenerarReporteVentasPorVendedorYFechas(int idAdministrador, int idVendedor, DateTime fechaInicio, DateTime fechaFin, out string mensajeError)
        {
            if (!ValidarAdministrador(idAdministrador, out mensajeError)) return null;
            if (idVendedor <= 0) { mensajeError = "ID de vendedor inválido."; return null; }
            if (fechaInicio > fechaFin) { mensajeError = "Fecha de inicio no puede ser posterior a fecha fin."; return null; }
            var datos = _ventaService.ObtenerVentasPorVendedorYFechas(idVendedor, fechaInicio, fechaFin);
            RegistrarMetadatoReporte(idAdministrador, "VENTAS POR VENDEDOR", filtroVendedorId: idVendedor, periodoInicio: fechaInicio, periodoFin: fechaFin);
            return datos;
        }
        public IEnumerable<Producto> GenerarReporteInventarioGeneral(int idAdministrador, out string mensajeError)
        {
            if (!ValidarAdministrador(idAdministrador, out mensajeError)) return null;
            var datos = _productoService.ObtenerTodosLosProductos();
            RegistrarMetadatoReporte(idAdministrador, "INVENTARIO GENERAL");
            return datos;
        }
        public IEnumerable<Producto> GenerarReporteInventarioPorVendedor(int idAdministrador, int idVendedor, out string mensajeError)
        {
            if (!ValidarAdministrador(idAdministrador, out mensajeError)) return null;
            if (idVendedor <= 0) { mensajeError = "ID de vendedor inválido."; return null; }
            var datos = _productoService.ObtenerProductosPorVendedor(idVendedor);
            RegistrarMetadatoReporte(idAdministrador, "INVENTARIO POR VENDEDOR", filtroVendedorId: idVendedor);
            return datos;
        }
        public IEnumerable<Cliente> GenerarReporteListadoClientes(int idAdministrador, out string mensajeError)
        {
            if (!ValidarAdministrador(idAdministrador, out mensajeError)) return null;
            var datos = _clienteService.ObtenerTodosLosClientes();
            RegistrarMetadatoReporte(idAdministrador, "LISTA DE CLIENTES");
            return datos;
        }
        public IEnumerable<Reporte> ObtenerHistorialDeReportes(int idAdministrador, out string mensajeError)
        {
            if (!ValidarAdministrador(idAdministrador, out mensajeError)) return null;
            mensajeError = string.Empty;
            return _reporteRepository.GetAll(); // Asumiendo que GetAll no necesita el idAdmin para filtrar, o se hace en DAL.
        }
    }
}
