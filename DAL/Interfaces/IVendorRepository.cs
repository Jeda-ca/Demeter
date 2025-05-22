using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IVendedorRepository : IGenericRepository<Vendedor>
    {
        Vendedor GetByUsuarioId(int usuarioId);
        Vendedor GetByCodigoVendedor(string codigo);
        IEnumerable<Vendedor> SearchByNombreOApellido(string searchTerm);
        Vendedor GetByNumeroDocumento(int tipoDocumentoId, string numeroDocumento);
    }
}
