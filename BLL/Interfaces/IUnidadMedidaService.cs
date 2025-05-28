using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUnidadMedidaService
    {
        IEnumerable<UnidadMedida> ObtenerTodas();
        UnidadMedida ObtenerPorId(int id);
    }
}
