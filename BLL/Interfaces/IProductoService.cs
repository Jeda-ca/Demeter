using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductoService
    {
        IEnumerable<Producto> ObtenerProductosPorVendedor(int idVendedor);
        IEnumerable<Producto> ObtenerTodosLosProductos(); // Para Admin
        Producto ObtenerProductoPorId(int idProducto);
        IEnumerable<Producto> BuscarProductosPorNombre(string nombre, int? idVendedor = null); // idVendedor opcional para filtrar
        IEnumerable<Producto> BuscarProductosPorCategoria(int idCategoria, int? idVendedor = null);

        string RegistrarNuevoProducto(Producto producto, int idUsuarioQueRegistra); // idUsuario puede ser Admin o Vendedor
        string ModificarProducto(Producto producto, int idUsuarioQueModifica);
        string CambiarEstadoActividadProducto(int idProducto, bool activo, int idUsuarioQueModifica); // Reemplaza Eliminar

        string AjustarStock(int idProducto, int cantidadAjuste, string motivo, bool esIncremento, int idUsuarioQueAjusta);
    }
}
