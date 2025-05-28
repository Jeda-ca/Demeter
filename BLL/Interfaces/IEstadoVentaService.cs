using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEstadoVentaService
    {
        IEnumerable<EstadoVenta> ObtenerTodos();
        EstadoVenta ObtenerPorId(int id);
        EstadoVenta ObtenerPorNombre(string nombre);
    }
}
