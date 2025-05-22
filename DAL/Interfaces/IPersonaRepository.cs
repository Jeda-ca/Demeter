using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPersonaRepository // No es un IGenericRepository<Persona> porque Persona es abstracta
                                        // y las operaciones directas sobre ella son limitadas.
                                        // Se usa principalmente para validaciones o búsquedas comunes.
    {
        bool ExistePersonaPorDocumento(int tipoDocumentoId, string numeroDocumento);
        Persona GetPersonaPorDocumento(int tipoDocumentoId, string numeroDocumento); // Devuelve Persona, la BLL determinará el subtipo si es necesario
    }

}
