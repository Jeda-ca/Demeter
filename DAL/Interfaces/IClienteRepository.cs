using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Cliente GetByCodigoCliente(string codigo);
        IEnumerable<Cliente> SearchByNombreOApellido(string searchTerm);
        Cliente GetByNumeroDocumento(int tipoDocumentoId, string numeroDocumento); // Para búsqueda por documento
    }
}
