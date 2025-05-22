using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUsuarioService
    {
        Usuario AutenticarUsuario(string nombreUsuario, string contrasena);
        IEnumerable<Usuario> ObtenerTodosLosUsuariosDelSistema();
        Usuario ObtenerUsuarioPorId(int idUsuario);
        Usuario ObtenerUsuarioPorNombreUsuario(string nombreUsuario);
        string RegistrarNuevoVendedorComoUsuario(Vendedor vendedor, string contrasena);
        string RegistrarNuevoAdministradorComoUsuario(Administrador admin, string contrasena);
        string ModificarDatosBasicosUsuario(int idUsuario, string nuevoNombreUsuario, string nuevaContrasena);
    }
}
