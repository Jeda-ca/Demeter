using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRolService
    {
        IEnumerable<Rol> ObtenerTodosLosRoles();
        Rol ObtenerRolPorId(int idRol);
        Rol ObtenerRolPorNombre(string nombre);
    }
}
