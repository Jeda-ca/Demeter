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
    public class VendedorService : IVendedorService
    {
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPersonaRepository _personaRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IVentaRepository _ventaRepository;


        public VendedorService()
        {
            _vendedorRepository = new VendedorRepository();
            _usuarioRepository = new UsuarioRepository();
            _personaRepository = new PersonaRepository();
            _productoRepository = new ProductoRepository();
            _ventaRepository = new VentaRepository();
        }

        public VendedorService(IVendedorRepository vendedorRepository, IUsuarioRepository usuarioRepository, IPersonaRepository personaRepository, IProductoRepository productoRepository, IVentaRepository ventaRepository)
        {
            _vendedorRepository = vendedorRepository ?? throw new ArgumentNullException(nameof(vendedorRepository));
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _personaRepository = personaRepository ?? throw new ArgumentNullException(nameof(personaRepository));
            _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
            _ventaRepository = ventaRepository ?? throw new ArgumentNullException(nameof(ventaRepository));
        }

        // ... (resto de los métodos de VendedorService sin cambios en su lógica interna) ...
        public IEnumerable<Vendedor> ObtenerTodosLosVendedores()
        {
            try
            {
                return _vendedorRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener todos los vendedores.", ex);
            }
        }
        public Vendedor ObtenerVendedorPorId(int idVendedor)
        {
            if (idVendedor <= 0) throw new ArgumentException("ID de vendedor inválido.", nameof(idVendedor));
            try
            {
                return _vendedorRepository.GetById(idVendedor);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener vendedor con ID {idVendedor}.", ex);
            }
        }
        public Vendedor ObtenerVendedorPorCodigo(string codigoVendedor)
        {
            if (string.IsNullOrWhiteSpace(codigoVendedor)) throw new ArgumentException("Código de vendedor no puede estar vacío.", nameof(codigoVendedor));
            try
            {
                return _vendedorRepository.GetByCodigoVendedor(codigoVendedor);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener vendedor con código {codigoVendedor}.", ex);
            }
        }
        public Vendedor ObtenerVendedorPorUsuarioId(int idUsuario)
        {
            if (idUsuario <= 0) throw new ArgumentException("ID de usuario inválido.", nameof(idUsuario));
            try
            {
                return _vendedorRepository.GetByUsuarioId(idUsuario);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener vendedor para el usuario ID {idUsuario}.", ex);
            }
        }
        public IEnumerable<Vendedor> BuscarVendedoresPorNombreOApellido(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return ObtenerTodosLosVendedores();
            try
            {
                return _vendedorRepository.SearchByNombreOApellido(searchTerm);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al buscar vendedores con el término '{searchTerm}'.", ex);
            }
        }
        public Vendedor ObtenerVendedorPorDocumento(int tipoDocumentoId, string numeroDocumento)
        {
            if (tipoDocumentoId <= 0) throw new ArgumentException("Tipo de documento inválido.", nameof(tipoDocumentoId));
            if (string.IsNullOrWhiteSpace(numeroDocumento)) throw new ArgumentException("Número de documento no puede estar vacío.", nameof(numeroDocumento));
            try
            {
                return _vendedorRepository.GetByNumeroDocumento(tipoDocumentoId, numeroDocumento);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener vendedor por documento {tipoDocumentoId}-{numeroDocumento}.", ex);
            }
        }
        public string ModificarVendedor(Vendedor vendedor, int idAdminQueModifica)
        {
            // ... (validaciones como antes) ...
            try
            {
                var adminUser = _usuarioRepository.GetById(idAdminQueModifica); // Busca por IdUsuario
                if (adminUser == null || !(adminUser is Administrador) || !adminUser.Activo)
                {
                    return "Operación no permitida. Se requiere un administrador activo."; // Este es el error que veías
                }

                var vendedorExistente = _vendedorRepository.GetById(vendedor.IdVendedor);
                if (vendedorExistente == null) return "Vendedor a modificar no encontrado.";

                // ... (validaciones de unicidad como antes) ...

                // Mantener HashContrasena y RolId del existente si no se cambian explícitamente
                vendedor.HashContrasena = vendedorExistente.HashContrasena;
                vendedor.RolId = vendedorExistente.RolId;
                vendedor.Activo = vendedorExistente.Activo; // El estado se maneja por CambiarEstadoActividadVendedor

                bool actualizado = _vendedorRepository.Update(vendedor);
                return actualizado ? $"Vendedor '{vendedor.Nombre} {vendedor.Apellido}' modificado." : "Error al modificar el vendedor.";
            }
            catch (InvalidOperationException ioex) { return ioex.Message; }
            catch (Exception ex) { return $"Error al modificar vendedor: {ex.Message}"; }
        }

        public string CambiarEstadoActividadVendedor(int idVendedor, bool nuevoEstado, int idAdminQueModifica)
        {
            // ... (validaciones como antes) ...
            try
            {
                var admin = _usuarioRepository.GetById(idAdminQueModifica);
                if (admin == null || !(admin is Administrador) || !admin.Activo)
                {
                    return "Operación no permitida. Se requiere un administrador activo.";
                }

                var vendedor = _vendedorRepository.GetById(idVendedor);
                if (vendedor == null) return "Vendedor no encontrado.";

                if (!nuevoEstado) // Si se va a inactivar
                {
                    var productosActivos = _productoRepository.GetByVendedorId(idVendedor).Any(p => p.Activo);
                    if (productosActivos) return $"No se puede inactivar. El vendedor ID {idVendedor} tiene productos activos.";

                    var ventasPendientes = _ventaRepository.GetByVendedorId(idVendedor)
                                            .Any(v => v.EstadoVenta != null && v.EstadoVenta.Nombre.ToUpper() == "PENDIENTE");
                    if (ventasPendientes) return $"No se puede inactivar. El vendedor ID {idVendedor} tiene ventas pendientes.";
                }

                bool actualizado = _usuarioRepository.UpdateUserStatus(vendedor.IdUsuario, nuevoEstado);
                return actualizado ? $"Estado del vendedor ID {idVendedor} cambiado." : "No se pudo cambiar el estado.";
            }
            catch (Exception ex) { return $"Error al cambiar estado del vendedor: {ex.Message}"; }
        }
    }
}
