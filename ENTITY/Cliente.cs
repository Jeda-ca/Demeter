using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ENTITY
{
    public class Cliente : Persona
    {
        public int IdCliente { get; set; } // PK de la tabla cliente
        // IdPersona y demás propiedades de Persona se heredan.
        public string CodigoCliente { get; set; }
        public DateTime? UltimaCompra { get; set; } // Nullable
        public string Correo { get; set; } // Nullable
        public bool Activo { get; set; }

        public ICollection<Venta> ComprasRealizadas { get; set; }

        public Cliente()
        {
            ComprasRealizadas = new HashSet<Venta>();
        }
    }
}
