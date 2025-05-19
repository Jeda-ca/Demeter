using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ENTITY
{
    public class Vendedor : Usuario
    {
        public int IdVendedor { get; set; } // PK de la tabla vendedor
        // IdUsuario, IdPersona y demás propiedades de Usuario y Persona se heredan.
        public string CodigoVendedor { get; set; }

        public ICollection<Producto> ProductosRegistrados { get; set; }
        public ICollection<Venta> VentasRealizadas { get; set; }

        public Vendedor()
        {
            ProductosRegistrados = new HashSet<Producto>();
            VentasRealizadas = new HashSet<Venta>();
        }

    }
}
