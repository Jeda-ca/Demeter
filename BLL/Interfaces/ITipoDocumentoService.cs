using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITipoDocumentoService
    {
        IEnumerable<TipoDocumento> ObtenerTodos();
        TipoDocumento ObtenerPorId(int id);
    }
}
