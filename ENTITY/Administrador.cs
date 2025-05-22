using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ENTITY
{
    public class Administrador : Usuario
    {
        public int IdAdministrador { get; set; } // PK de la tabla administrador
        // IdUsuario, IdPersona y demás propiedades de Usuario y Persona se heredan.
        // La DAL se encargará del mapeo desde las tablas correspondientes.

        public ICollection<Reporte> ReportesGenerados { get; set; }

        public Administrador()
        {
            ReportesGenerados = new HashSet<Reporte>();
        }
    }
}
