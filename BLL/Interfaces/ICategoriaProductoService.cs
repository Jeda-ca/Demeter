using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICategoriaProductoService
    {
        IEnumerable<CategoriaProducto> ObtenerTodas();
        CategoriaProducto ObtenerPorId(int id);
        CategoriaProducto ObtenerPorNombre(string nombre);
        string AgregarCategoria(CategoriaProducto categoria);
        string ActualizarCategoria(CategoriaProducto categoria);
        string EliminarCategoria(int idCategoria);
    }
}
