using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public abstract class Usuario : Persona
    {
        public int IdUsuario { get; set; } 
        public string NombreUsuario { get; set; }
        public string HashContrasena { get; set; }
        public int RolId { get; set; } // FK
        public Rol Rol { get; set; }
        public bool Activo { get; set; }
    }
}
