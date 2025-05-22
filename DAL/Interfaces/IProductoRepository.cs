using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Interfaces
{
    public interface IProductoRepository : IGenericRepository<Producto>
    {
        IEnumerable<Producto> GetByVendedorId(int vendedorId);
        IEnumerable<Producto> GetByCategoriaId(int categoriaId);
        // SearchByName ya está, pero podría refinarse para aceptar vendedorId si es común
        IEnumerable<Producto> SearchByNameAndVendedor(string partialName, int vendedorId);
        bool RegistrarVentaStock(int productoId, int cantidadVendida);
        bool IncrementarStock(int productoId, int cantidadAgregada);
        bool AjustarStockPorMerma(int productoId, int cantidadADecrementar, string motivoAjuste);
    }
}
