using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace DAL.Interfaces
{
    public interface IAdministradorRepository : IGenericRepository<Administrador>
    {
        Administrador GetByUsuarioId(int usuarioId);
        // Para búsquedas, se buscaría por datos de Persona (nombre, documento) a través de JOINs
        IEnumerable<Administrador> SearchByNombreOApellido(string searchTerm);
        Administrador GetByNumeroDocumento(int tipoDocumentoId, string numeroDocumento);
    }
}
