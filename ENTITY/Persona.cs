using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public abstract class Persona
    {
        public int IdPersona { get; set; } // PK de la tabla persona
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoDocumentoId { get; set; } // FK
        public string NumeroDocumento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Telefono { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
    }
}
