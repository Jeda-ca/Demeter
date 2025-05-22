using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICategoriaProductoRepository : IGenericRepository<CategoriaProducto>
    {
        CategoriaProducto GetByName(string name);
    }
}
