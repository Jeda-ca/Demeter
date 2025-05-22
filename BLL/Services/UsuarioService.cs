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
                if (usuario != null && VerifyPassword(contrasena, usuario.HashContrasena))
                {
                    return usuario;
                }
                return null;
            }
            catch (Exception ex) { throw new ApplicationException("Error durante la autenticación.", ex); }
        }

        public IEnumerable<Usuario> ObtenerTodosLosUsuariosDelSistema()
        {
            try { return _usuarioRepository.GetAllSystemUsers(); }
            catch (Exception ex) { throw new ApplicationException("Error al obtener todos los usuarios del sistema.", ex); }
        }

        public Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            if (idUsuario <= 0) return null;
            try { return _usuarioRepository.GetById(idUsuario); }
            catch (Exception ex) { throw new ApplicationException($"Error al obtener usuario con ID {idUsuario}.", ex); }
        }

        public Usuario ObtenerUsuarioPorNombreUsuario(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario)) return null;
            try { return _usuarioRepository.GetByNombreUsuario(nombreUsuario); }
            catch (Exception ex) { throw new ApplicationException($"Error al obtener usuario con nombre '{nombreUsuario}'.", ex); }
        }

        public string RegistrarNuevoVendedorComoUsuario(Vendedor vendedor, string contrasena)
        {
            if (vendedor == null) return "Datos del vendedor no pueden ser nulos.";
            if (string.IsNullOrWhiteSpace(contrasena)) return "La contraseña es requerida.";

            try
            {
                var rolVendedor = _rolRepository.GetByName("VENDEDOR"); // Corregido a VENDEDOR
                if (rolVendedor == null) return "El rol 'VENDEDOR' no está configurado en el sistema.";

                vendedor.RolId = rolVendedor.IdRol;
                vendedor.Rol = rolVendedor;
                vendedor.HashContrasena = HashPassword(contrasena);
                if (vendedor.FechaRegistro == DateTime.MinValue) vendedor.FechaRegistro = DateTime.Now;

                var vendedorAgregado = _vendedorRepository.Add(vendedor);
                return vendedorAgregado != null && vendedorAgregado.IdVendedor > 0 ?
                       $"Vendedor '{vendedor.Nombre} {vendedor.Apellido}' registrado exitosamente." :
                       "Error al registrar el vendedor (verifique que el documento y username no existan y el código de vendedor sea único).";
            }
            catch (InvalidOperationException ioex) { return ioex.Message; }
            catch (Exception ex) { return $"Error al registrar vendedor: {ex.Message}"; }
        }

        public string RegistrarNuevoAdministradorComoUsuario(Administrador admin, string contrasena)
        {
            if (admin == null) return "Datos del administrador no pueden ser nulos.";
            if (string.IsNullOrWhiteSpace(contrasena)) return "La contraseña es requerida.";

            try
            {
                var rolAdmin = _rolRepository.GetByName("ADMIN");
                if (rolAdmin == null) return "El rol 'ADMIN' no está configurado en el sistema.";

                admin.RolId = rolAdmin.IdRol;
                admin.Rol = rolAdmin;
                admin.HashContrasena = HashPassword(contrasena);
                if (admin.FechaRegistro == DateTime.MinValue) admin.FechaRegistro = DateTime.Now;

                var adminAgregado = _administradorRepository.Add(admin);
                return adminAgregado != null && adminAgregado.IdAdministrador > 0 ?
                       $"Administrador '{admin.Nombre} {admin.Apellido}' registrado exitosamente." :
                       "Error al registrar el administrador (verifique que el documento y username no existan).";
            }
            catch (InvalidOperationException ioex) { return ioex.Message; }
            catch (Exception ex) { return $"Error al registrar administrador: {ex.Message}"; }
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
                if (!string.IsNullOrWhiteSpace(nuevoNombreUsuario))
                {
                    var usuarioExistente = _usuarioRepository.GetByNombreUsuario(nuevoNombreUsuario);
                    if (usuarioExistente != null && usuarioExistente.IdUsuario != idUsuario)
                    {
                        return $"El nombre de usuario '{nuevoNombreUsuario}' ya está en uso por otro usuario.";
                    }
                }

                string nuevoHash = string.IsNullOrWhiteSpace(nuevaContrasena) ? null : HashPassword(nuevaContrasena);

                bool actualizado = _usuarioRepository.UpdateUsuarioBasico(idUsuario, nuevoNombreUsuario, nuevoHash);
                return actualizado ?
                       "Datos básicos del usuario actualizados." :
                       "No se pudieron actualizar los datos básicos del usuario (usuario no encontrado o sin cambios).";
            }
            catch (Exception ex) { return $"Error al modificar datos básicos del usuario: {ex.Message}"; }
        }
    }
}
