using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public abstract class Usuario : Persona
    {
        public int IdUsuario { get; set; } // PK de la tabla usuario
        // IdPersona es heredado de la clase Persona.
        // La DAL se encargará de mapear persona.id_persona a la propiedad IdPersona heredada
        // y usuario.persona_id como el vínculo FK.

        public string NombreUsuario { get; set; }
        public string HashContrasena { get; set; }
        public int RolId { get; set; } // FK
        public Rol Rol { get; set; }
    }
}
