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
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IEstadoVentaRepository _estadoVentaRepository;

        public VentaService()
        {
            _productoRepository = new ProductoRepository();
            _ventaRepository = new VentaRepository(_productoRepository);
            _clienteRepository = new ClienteRepository();
            _vendedorRepository = new VendedorRepository();
            _estadoVentaRepository = new EstadoVentaRepository();
        }

        public VentaService(IVentaRepository ventaRepository,
                            IProductoRepository productoRepository,
                            IClienteRepository clienteRepository,
                            IVendedorRepository vendedorRepository,
                            IEstadoVentaRepository estadoVentaRepository)
        {
            _ventaRepository = ventaRepository ?? throw new ArgumentNullException(nameof(ventaRepository));
            _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _vendedorRepository = vendedorRepository ?? throw new ArgumentNullException(nameof(vendedorRepository));
            _estadoVentaRepository = estadoVentaRepository ?? throw new ArgumentNullException(nameof(estadoVentaRepository));
        }

        // ... (resto de los métodos de VentaService sin cambios en su lógica interna) ...
        public string RegistrarNuevaVenta(Venta venta, int idVendedorLogueado)
        {
            // ... (validaciones como antes) ...
            if (venta == null) return "Datos de la venta no pueden ser nulos.";
            if (venta.ClienteId <= 0) return "Se debe seleccionar un cliente.";
            if (idVendedorLogueado <= 0) return "Vendedor no identificado.";
            if (venta.DetallesVenta == null || !venta.DetallesVenta.Any()) return "La venta debe tener al menos un producto.";

            if (_clienteRepository.GetById(venta.ClienteId) == null) return "Cliente no encontrado.";

            var vendedor = _vendedorRepository.GetById(idVendedorLogueado);
            if (vendedor == null || !vendedor.Activo) return "Vendedor no encontrado o inactivo.";

            venta.VendedorId = idVendedorLogueado;

            foreach (var detalle in venta.DetallesVenta)
            {
                var productoEnRepo = _productoRepository.GetById(detalle.ProductoId);
                if (productoEnRepo == null) return $"Producto con ID {detalle.ProductoId} no encontrado.";
                if (!productoEnRepo.Activo) return $"El producto '{productoEnRepo.Nombre}' no está activo.";
                if (productoEnRepo.Stock < detalle.Cantidad)
                {
                    return $"Stock insuficiente para '{productoEnRepo.Nombre}'. Disp: {productoEnRepo.Stock}, Sol: {detalle.Cantidad}.";
                }
                detalle.Producto = productoEnRepo; // Asignar el producto completo al detalle
            }
            // ... (cálculo de totales y asignación de estado como antes) ...
            venta.Subtotal = venta.DetallesVenta.Sum(d => d.TotalLinea);
            venta.Total = venta.Subtotal - venta.Descuento;
            if (venta.Total < 0) return "El total de la venta no puede ser negativo.";

            if (venta.EstadoId == 0) // Si no se especificó un estado, por defecto es PENDIENTE
            {
                var estadoPendiente = _estadoVentaRepository.GetByName("PENDIENTE");
                if (estadoPendiente == null) return "Estado de venta 'PENDIENTE' no configurado.";
                venta.EstadoId = estadoPendiente.IdEstado;
            }


            try
            {
                var ventaRegistrada = _ventaRepository.AddVentaCompleta(venta);
                return ventaRegistrada != null && ventaRegistrada.IdVenta > 0 ?
                       $"Venta ID {ventaRegistrada.IdVenta} registrada." :
                       "Error al registrar la venta.";
            }
            catch (InvalidOperationException ioex) { return ioex.Message; }
            catch (Exception ex) { return $"Error al registrar la venta: {ex.Message}"; }
        }
        public IEnumerable<Venta> ObtenerVentasPorVendedor(int idVendedor)
        {
            if (idVendedor <= 0) throw new ArgumentException("ID de vendedor inválido.");
            return _ventaRepository.GetByVendedorId(idVendedor);
        }
        public IEnumerable<Venta> ObtenerVentasPorCliente(int idCliente) => _ventaRepository.GetByClienteId(idCliente);
        public IEnumerable<Venta> ObtenerVentasPorRangoFechas(DateTime inicio, DateTime fin) => _ventaRepository.GetByDateRange(inicio, fin);
        public IEnumerable<Venta> ObtenerVentasPorVendedorYFechas(int idVendedor, DateTime inicio, DateTime fin) => _ventaRepository.GetByVendedorAndDateRange(idVendedor, inicio, fin);
        public IEnumerable<Venta> ObtenerTodasLasVentasParaAdmin() => _ventaRepository.GetAll();
        public Venta ObtenerVentaPorId(int idVenta) => _ventaRepository.GetById(idVenta);

        public string CancelarVenta(int idVenta, string motivo)
        {
            if (idVenta <= 0) return "ID de venta inválido.";
            if (string.IsNullOrWhiteSpace(motivo)) return "Se requiere un motivo para la cancelación.";
            try
            {
                bool cancelada = _ventaRepository.CancelarVenta(idVenta, motivo);
                return cancelada ? $"Venta ID {idVenta} cancelada." : "No se pudo cancelar la venta.";
            }
            catch (InvalidOperationException ioex) { return ioex.Message; }
            catch (Exception ex) { return $"Error al cancelar la venta: {ex.Message}"; }
        }
    }
}
