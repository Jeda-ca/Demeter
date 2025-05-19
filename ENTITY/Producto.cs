using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; } // Nullable
        public decimal Precio { get; set; }
        public int UnidadMedidaId { get; set; }
        public int CategoriaId { get; set; }
        public int Stock { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacionStock { get; set; }
        public int VendedorId { get; set; } // FK al Vendedor que registró/posee el producto
        public bool Activo { get; set; }
        public UnidadMedida UnidadMedida { get; set; }
        public CategoriaProducto Categoria { get; set; }
        public Vendedor Vendedor { get; set; } // El vendedor que registró este producto
        public ICollection<DetalleVenta> DetallesVenta { get; set; }

        public Producto()
        {
            DetallesVenta = new HashSet<DetalleVenta>();
        }
    }
}
