using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IVentaRepository : IGenericRepository<Venta>
    {
        IEnumerable<Venta> GetByClienteId(int clienteId);

        IEnumerable<Venta> GetByVendedorId(int vendedorId);

        IEnumerable<Venta> GetByDateRange(DateTime startDate, DateTime endDate);

        IEnumerable<Venta> GetByVendedorAndDateRange(int vendedorId, DateTime startDate, DateTime endDate);

        Venta AddVentaCompleta(Venta venta);

        bool CancelarVenta(int idVenta, string motivoCancelacion);
    }
}
