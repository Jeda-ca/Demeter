using BLL.Interfaces;
using DAL.Interfaces;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IAdministradorRepository _administradorRepository;
        private readonly IRolRepository _rolRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              IVendedorRepository vendedorRepository,
                              IAdministradorRepository administradorRepository,
                              IRolRepository rolRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _vendedorRepository = vendedorRepository ?? throw new ArgumentNullException(nameof(vendedorRepository));
            _administradorRepository = administradorRepository ?? throw new ArgumentNullException(nameof(administradorRepository));
            _rolRepository = rolRepository ?? throw new ArgumentNullException(nameof(rolRepository));
        }

        private string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return null;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) { builder.Append(bytes[i].ToString("x2")); }
                return builder.ToString();
            }
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword)) return false;
            string hashOfInput = HashPassword(password);
            return StringComparer.OrdinalIgnoreCase.Compare(hashOfInput, hashedPassword) == 0;
        }

        public Usuario AutenticarUsuario(string nombreUsuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena)) return null;
            try
            {
                var usuario = _usuarioRepository.GetByNombreUsuario(nombreUsuario);
                if (usuario != null && VerifyPassword(contrasena, usuario.HashContrasena) && usuario.Activo)
                {
                    return usuario;
                }
                return null; 
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error durante la autenticación.", ex);
            }
        }

        public IEnumerable<Usuario> ObtenerTodosLosUsuariosDelSistema()
        {
            try
            {
                return _usuarioRepository.GetAllSystemUsers();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error al obtener todos los usuarios del sistema.", ex);
            }
        }

        public IEnumerable<Usuario> ObtenerTodosLosUsuariosActivosDelSistema()
        {
            try
            {
                return _usuarioRepository.GetAllSystemUsers().Where(u => u.Activo);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener todos los usuarios activos del sistema.", ex);
            }
        }


        public Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            if (idUsuario <= 0) return null;
            try
            {
                return _usuarioRepository.GetById(idUsuario);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener usuario con ID {idUsuario}.", ex);
            }
        }

        public Usuario ObtenerUsuarioPorNombreUsuario(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario)) return null;
            try
            {
                return _usuarioRepository.GetByNombreUsuario(nombreUsuario);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener usuario con nombre '{nombreUsuario}'.", ex);
            }
        }

        public string RegistrarNuevoVendedorComoUsuario(Vendedor vendedor, string contrasena)
        {
            if (vendedor == null) return "Datos del vendedor no pueden ser nulos.";
            if (string.IsNullOrWhiteSpace(contrasena)) return "La contraseña es requerida.";
            if (string.IsNullOrWhiteSpace(vendedor.Nombre)) return "El nombre del vendedor es requerido.";
            if (string.IsNullOrWhiteSpace(vendedor.Apellido)) return "El apellido del vendedor es requerido.";
            if (vendedor.TipoDocumentoId <= 0) return "El tipo de documento es requerido.";
            if (string.IsNullOrWhiteSpace(vendedor.NumeroDocumento)) return "El número de documento es requerido.";
            if (string.IsNullOrWhiteSpace(vendedor.NombreUsuario)) return "El nombre de usuario es requerido.";
            if (string.IsNullOrWhiteSpace(vendedor.CodigoVendedor)) return "El código de vendedor es requerido.";


            try
            {
                var rolVendedor = _rolRepository.GetByName("VENDEDOR");
                if (rolVendedor == null) return "El rol 'VENDEDOR' no está configurado en el sistema.";

                vendedor.RolId = rolVendedor.IdRol;
                vendedor.Rol = rolVendedor; 
                vendedor.HashContrasena = HashPassword(contrasena);
                if (vendedor.FechaRegistro == DateTime.MinValue) vendedor.FechaRegistro = DateTime.Now;
                vendedor.Activo = true; 

                var vendedorAgregado = _vendedorRepository.Add(vendedor);
                return vendedorAgregado != null && vendedorAgregado.IdVendedor > 0 ?
                       $"Vendedor '{vendedor.Nombre} {vendedor.Apellido}' registrado exitosamente." :
                       "Error al registrar el vendedor (verifique que el documento, username y código de vendedor no existan o sean únicos).";
            }
            catch (InvalidOperationException ioex) { return ioex.Message; } 
            catch (Exception ex)
            {

                return $"Error al registrar vendedor: {ex.Message}";
            }
        }

        public string RegistrarNuevoAdministradorComoUsuario(Administrador admin, string contrasena)
        {
            if (admin == null) return "Datos del administrador no pueden ser nulos.";
            if (string.IsNullOrWhiteSpace(contrasena)) return "La contraseña es requerida.";
            if (string.IsNullOrWhiteSpace(admin.Nombre)) return "El nombre del administrador es requerido.";

            try
            {
                var rolAdmin = _rolRepository.GetByName("ADMIN");
                if (rolAdmin == null) return "El rol 'ADMIN' no está configurado en el sistema.";

                admin.RolId = rolAdmin.IdRol;
                admin.Rol = rolAdmin; 
                admin.HashContrasena = HashPassword(contrasena);
                if (admin.FechaRegistro == DateTime.MinValue) admin.FechaRegistro = DateTime.Now;
                admin.Activo = true; 

                var adminAgregado = _administradorRepository.Add(admin);
                return adminAgregado != null && adminAgregado.IdAdministrador > 0 ?
                       $"Administrador '{admin.Nombre} {admin.Apellido}' registrado exitosamente." :
                       "Error al registrar el administrador (verifique que el documento y username no existan).";
            }
            catch (InvalidOperationException ioex) { return ioex.Message; }
            catch (Exception ex)
            {

                return $"Error al registrar administrador: {ex.Message}";
            }
        }

        public string ModificarDatosBasicosUsuario(int idUsuario, string nuevoNombreUsuario, string nuevaContrasena)
        {
            if (idUsuario <= 0) return "ID de usuario inválido.";
            if (string.IsNullOrWhiteSpace(nuevoNombreUsuario) && string.IsNullOrWhiteSpace(nuevaContrasena))
            {
                return "Debe proporcionar un nuevo nombre de usuario o una nueva contraseña.";
            }

            try
            {
                var usuarioActual = _usuarioRepository.GetById(idUsuario);
                if (usuarioActual == null) return "Usuario no encontrado.";

                if (!string.IsNullOrWhiteSpace(nuevoNombreUsuario) && nuevoNombreUsuario != usuarioActual.NombreUsuario)
                {
                    var usuarioExistenteConNuevoNombre = _usuarioRepository.GetByNombreUsuario(nuevoNombreUsuario);
                    if (usuarioExistenteConNuevoNombre != null && usuarioExistenteConNuevoNombre.IdUsuario != idUsuario)
                    {
                        return $"El nombre de usuario '{nuevoNombreUsuario}' ya está en uso por otro usuario.";
                    }
                }

                string hashParaActualizar = usuarioActual.HashContrasena;
                if (!string.IsNullOrWhiteSpace(nuevaContrasena))
                {
                    hashParaActualizar = HashPassword(nuevaContrasena);
                }


                bool actualizado = _usuarioRepository.UpdateUsuarioBasico(idUsuario, nuevoNombreUsuario, hashParaActualizar);

                return actualizado ?
                       "Datos básicos del usuario actualizados." :
                       "No se pudieron actualizar los datos básicos del usuario (usuario no encontrado o sin cambios efectivos).";
            }
            catch (Exception ex)
            {

                return $"Error al modificar datos básicos del usuario: {ex.Message}";
            }
        }

        public string CambiarEstadoActividadUsuario(int idUsuarioAModificar, bool nuevoEstado, int idAdminQueModifica)
        {
            if (idUsuarioAModificar <= 0) return "ID de usuario a modificar inválido.";
            if (idAdminQueModifica <= 0) return "ID de administrador que modifica inválido.";

            try
            {
                var admin = _usuarioRepository.GetById(idAdminQueModifica);
                if (admin == null || !(admin is Administrador) || !admin.Activo)
                {
                    return "Operación no permitida. Se requiere un administrador activo.";
                }

                var usuarioAModificar = _usuarioRepository.GetById(idUsuarioAModificar);
                if (usuarioAModificar == null)
                {
                    return "Usuario a modificar no encontrado.";
                }

                if (usuarioAModificar.IdUsuario == idAdminQueModifica && !nuevoEstado)
                {
                    return "Un administrador no puede inactivarse a sí mismo mediante esta función.";
                }

                bool actualizado = _usuarioRepository.UpdateUserStatus(idUsuarioAModificar, nuevoEstado);

                if (actualizado)
                {
                    return $"Estado de actividad del usuario ID {idUsuarioAModificar} cambiado a {(nuevoEstado ? "Activo" : "Inactivo")}.";
                }
                else
                {
                    return "No se pudo cambiar el estado de actividad del usuario.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al cambiar estado de actividad del usuario: {ex.Message}";
            }
        }
    }
}
