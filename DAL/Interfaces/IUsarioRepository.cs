using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario GetById(int idUsuario); // Devuelve Usuario, que puede ser Admin o Vendedor
        Usuario GetByNombreUsuario(string nombreUsuario);
        IEnumerable<Usuario> GetAllSystemUsers(); // Para listar todos los usuarios (Admin y Vendedores)
        bool UpdateUsuarioBasico(int idUsuario, string nuevoNombreUsuario, string nuevoHashContrasena); 
        // Para que el admin cambie datos básicos
        // Add/Delete/Update completo se maneja vía AdministradorRepository o VendedorRepository
    }
}
