using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITipoDocumentoRepository : IGenericRepository<TipoDocumento>
    {
        TipoDocumento GetByName (string name);
    }
}
