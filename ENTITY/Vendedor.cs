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
        public int IdVendedor { get; set; } 
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
