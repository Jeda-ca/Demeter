using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDetalleVentaRepository : IGenericRepository<DetalleVenta> 
    // CRUD básico para detalles si es necesario aisladamente
    {
        IEnumerable<DetalleVenta> GetByVentaId(int ventaId);
        // Add, Update, Delete de detalles individuales usualmente se manejan como parte de la Venta,
        // pero tener la interfaz permite flexibilidad.
    }
}
