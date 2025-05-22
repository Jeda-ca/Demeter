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
    public class VendedorService : IVendedorService
    {
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IUsuarioRepository _usuarioRepository; // Para cambiar estado y validar
        private readonly IPersonaRepository _personaRepository; // Para validaciones de documento
        private readonly IProductoRepository _productoRepository; // Para verificar si tiene productos activos
        private readonly IVentaRepository _ventaRepository; // Para verificar si tiene ventas pendientes


        public VendedorService(IVendedorRepository vendedorRepository,
                               IUsuarioRepository usuarioRepository,
                               IPersonaRepository personaRepository,
                               IProductoRepository productoRepository,
                               IVentaRepository ventaRepository)
        {
            _vendedorRepository = vendedorRepository ?? throw new ArgumentNullException(nameof(vendedorRepository));
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _personaRepository = personaRepository ?? throw new ArgumentNullException(nameof(personaRepository));
            _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
            _ventaRepository = ventaRepository ?? throw new ArgumentNullException(nameof(ventaRepository));
        }

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

        public IEnumerable<Vendedor> ObtenerTodosLosVendedoresActivos()
        {
            try
            {
                return _vendedorRepository.GetAll().Where(v => v.Activo);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener todos los vendedores activos.", ex);
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
            if (vendedor == null) return "Datos del vendedor no pueden ser nulos.";
            if (vendedor.IdVendedor <= 0 || vendedor.IdUsuario <= 0 || vendedor.IdPersona <= 0) return "IDs de Vendedor, Usuario y Persona son requeridos para la modificación.";
            if (idAdminQueModifica <= 0) return "Se requiere identificar al administrador que realiza la modificación.";

            // Validaciones básicas de datos
            if (string.IsNullOrWhiteSpace(vendedor.Nombre)) return "El nombre del vendedor es requerido.";
            if (string.IsNullOrWhiteSpace(vendedor.Apellido)) return "El apellido del vendedor es requerido.";
            if (vendedor.TipoDocumentoId <= 0) return "El tipo de documento es requerido.";
            if (string.IsNullOrWhiteSpace(vendedor.NumeroDocumento)) return "El número de documento es requerido.";
            if (string.IsNullOrWhiteSpace(vendedor.NombreUsuario)) return "El nombre de usuario es requerido.";
            if (string.IsNullOrWhiteSpace(vendedor.CodigoVendedor)) return "El código de vendedor es requerido.";
            // No se modifica la contraseña aquí, eso se hace en UsuarioService.ModificarDatosBasicosUsuario

            try
            {
                var admin = _usuarioRepository.GetById(idAdminQueModifica);
                if (admin == null || !(admin is Administrador) || !admin.Activo)
                {
                    return "Operación no permitida. Se requiere un administrador activo.";
                }

                var vendedorExistente = _vendedorRepository.GetById(vendedor.IdVendedor);
                if (vendedorExistente == null) return "Vendedor a modificar no encontrado.";

                // Validar unicidad de NombreUsuario si ha cambiado
                if (vendedor.NombreUsuario != vendedorExistente.NombreUsuario)
                {
                    var otroUsuarioConMismoNombre = _usuarioRepository.GetByNombreUsuario(vendedor.NombreUsuario);
                    if (otroUsuarioConMismoNombre != null && otroUsuarioConMismoNombre.IdUsuario != vendedor.IdUsuario)
                    {
                        return $"El nombre de usuario '{vendedor.NombreUsuario}' ya está en uso.";
                    }
                }

                // Validar unicidad de Documento si ha cambiado
                if (vendedor.NumeroDocumento != vendedorExistente.NumeroDocumento || vendedor.TipoDocumentoId != vendedorExistente.TipoDocumentoId)
                {
                    if (_personaRepository.ExistePersonaPorDocumento(vendedor.TipoDocumentoId, vendedor.NumeroDocumento))
                    {
                        var otraPersona = _personaRepository.GetPersonaPorDocumento(vendedor.TipoDocumentoId, vendedor.NumeroDocumento);
                        if (otraPersona != null && otraPersona.IdPersona != vendedor.IdPersona) // Asegurarse que no es la misma persona
                            return $"El documento '{vendedor.TipoDocumento.Nombre} {vendedor.NumeroDocumento}' ya está registrado para otra persona.";
                    }
                }

                // Validar unicidad de CodigoVendedor si ha cambiado
                if (vendedor.CodigoVendedor != vendedorExistente.CodigoVendedor)
                {
                    var otroVendedorConMismoCodigo = _vendedorRepository.GetByCodigoVendedor(vendedor.CodigoVendedor);
                    if (otroVendedorConMismoCodigo != null && otroVendedorConMismoCodigo.IdVendedor != vendedor.IdVendedor)
                    {
                        return $"El código de vendedor '{vendedor.CodigoVendedor}' ya está en uso.";
                    }
                }

                // Mantener el HashContrasena y RolId del existente, ya que no se modifican aquí.
                vendedor.HashContrasena = vendedorExistente.HashContrasena;
                vendedor.RolId = vendedorExistente.RolId;
                // El estado 'Activo' del usuario se maneja con CambiarEstadoActividadVendedor

                bool actualizado = _vendedorRepository.Update(vendedor);
                return actualizado ?
                       $"Vendedor '{vendedor.Nombre} {vendedor.Apellido}' modificado exitosamente." :
                       "Error al modificar el vendedor.";
            }
            catch (InvalidOperationException ioex) { return ioex.Message; }
            catch (Exception ex)
            {
                return $"Error al modificar vendedor: {ex.Message}";
            }
        }

        public string CambiarEstadoActividadVendedor(int idVendedor, bool nuevoEstado, int idAdminQueModifica)
        {
            if (idVendedor <= 0) return "ID de vendedor inválido.";
            if (idAdminQueModifica <= 0) return "ID de administrador que modifica inválido.";

            try
            {
                var admin = _usuarioRepository.GetById(idAdminQueModifica);
                if (admin == null || !(admin is Administrador) || !admin.Activo)
                {
                    return "Operación no permitida. Se requiere un administrador activo.";
                }

                var vendedor = _vendedorRepository.GetById(idVendedor);
                if (vendedor == null) return "Vendedor no encontrado.";

                // Lógica de negocio antes de inactivar (si aplica)
                if (!nuevoEstado) // Si se va a inactivar
                {

                    var productosActivos = _productoRepository.GetByVendedorId(idVendedor).Any(p => p.Activo);
                    if (productosActivos)
                    {
                        return $"No se puede inactivar el vendedor ID {idVendedor} porque tiene productos activos. Inactive los productos primero.";
                    }

                    var ventasPendientes = _ventaRepository.GetByVendedorId(idVendedor)
                                            .Any(v => v.EstadoVenta != null && v.EstadoVenta.Nombre.ToUpper() == "PENDIENTE");
                    if (ventasPendientes)
                    {
                        return $"No se puede inactivar el vendedor ID {idVendedor} porque tiene ventas pendientes. Complete o cancele las ventas primero.";
                    }
                }

                bool actualizado = _usuarioRepository.UpdateUserStatus(vendedor.IdUsuario, nuevoEstado);

                if (actualizado)
                {
                    return $"Estado de actividad del vendedor ID {idVendedor} (Usuario ID {vendedor.IdUsuario}) cambiado a {(nuevoEstado ? "Activo" : "Inactivo")}.";
                }
                else
                {
                    return "No se pudo cambiar el estado de actividad del vendedor.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al cambiar estado de actividad del vendedor: {ex.Message}";
            }
        }
    }
}
