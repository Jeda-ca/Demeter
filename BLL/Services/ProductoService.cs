using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ProductoService()
        {
            _productoRepository = new ProductoRepository();
            _vendedorRepository = new VendedorRepository();
            _usuarioRepository = new UsuarioRepository();
        }

        public ProductoService(IProductoRepository productoRepository, IVendedorRepository vendedorRepository, IUsuarioRepository usuarioRepository)
        {
            _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
            _vendedorRepository = vendedorRepository ?? throw new ArgumentNullException(nameof(vendedorRepository));
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }

        public IEnumerable<Producto> ObtenerProductosPorVendedor(int idVendedor)
        {
            if (idVendedor <= 0) throw new ArgumentException("ID de vendedor inválido.", nameof(idVendedor));
            try { return _productoRepository.GetByVendedorId(idVendedor); }
            catch (Exception ex) { throw new ApplicationException($"Error al obtener productos para el vendedor ID {idVendedor}.", ex); }
        }

        public IEnumerable<Producto> ObtenerTodosLosProductos()
        {
            try { return _productoRepository.GetAll(); }
            catch (Exception ex) { throw new ApplicationException("Error al obtener todos los productos.", ex); }
        }
        public Producto ObtenerProductoPorId(int idProducto)
        {
            if (idProducto <= 0) throw new ArgumentException("ID de producto inválido.", nameof(idProducto));
            try { return _productoRepository.GetById(idProducto); }
            catch (Exception ex) { throw new ApplicationException($"Error al obtener producto con ID {idProducto}.", ex); }
        }
        public IEnumerable<Producto> BuscarProductosPorNombre(string nombre, int? idVendedor = null)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return idVendedor.HasValue ? ObtenerProductosPorVendedor(idVendedor.Value) : ObtenerTodosLosProductos();
            try
            {
                if (idVendedor.HasValue)
                {
                    return _productoRepository.SearchByNameAndVendedor(nombre, idVendedor.Value);
                }
                // Si no se especifica vendedor, buscar en todos los productos (para admin)
                var todos = _productoRepository.GetAll();
                return todos.Where(p => p.Nombre.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            catch (Exception ex) { throw new ApplicationException($"Error al buscar productos por nombre '{nombre}'.", ex); }
        }

        public IEnumerable<Producto> BuscarProductosPorCategoria(int idCategoria, int? idVendedor = null)
        {
            if (idCategoria <= 0) throw new ArgumentException("ID de categoría inválido.");
            try
            {
                var productosPorCategoria = _productoRepository.GetByCategoriaId(idCategoria);
                if (idVendedor.HasValue)
                {
                    return productosPorCategoria.Where(p => p.VendedorId == idVendedor.Value);
                }
                return productosPorCategoria;
            }
            catch (Exception ex) { throw new ApplicationException($"Error al buscar productos por categoría ID {idCategoria}.", ex); }
        }
        public string RegistrarNuevoProducto(Producto producto, int idUsuarioQueRegistra)
        {
            if (producto == null) throw new ArgumentNullException(nameof(producto));
            if (idUsuarioQueRegistra <= 0) return "Usuario que registra inválido.";

            var usuario = _usuarioRepository.GetById(idUsuarioQueRegistra);
            if (usuario == null) return "Usuario que registra no encontrado.";

            int idVendedorParaProducto;

            if (usuario is Vendedor vendedor)
            {
                idVendedorParaProducto = vendedor.IdVendedor;
            }
            else if (usuario is Administrador)
            {
                // Si un admin registra, el producto DEBE tener un VendedorId asignado
                if (producto.VendedorId <= 0) return "Para registro por admin, se debe especificar el ID del vendedor dueño del producto.";
                if (_vendedorRepository.GetById(producto.VendedorId) == null) return "El vendedor especificado para el producto no existe.";
                idVendedorParaProducto = producto.VendedorId;
            }
            else
            {
                return "El usuario no tiene permisos para registrar productos.";
            }

            if (string.IsNullOrWhiteSpace(producto.Nombre)) return "El nombre del producto es requerido.";
            // ... (otras validaciones de producto) ...

            try
            {
                producto.VendedorId = idVendedorParaProducto; // Asegurar que el VendedorId correcto esté asignado
                producto.Activo = true;
                producto.FechaCreacion = DateTime.Now;
                producto.FechaActualizacionStock = DateTime.Now;

                var productoAgregado = _productoRepository.Add(producto);
                return productoAgregado != null && productoAgregado.IdProducto > 0 ?
                       $"Producto '{producto.Nombre}' registrado exitosamente." :
                       "Error al registrar el producto.";
            }
            catch (Exception ex) { return $"Error al registrar producto: {ex.Message}"; }
        }
        public string ModificarProducto(Producto producto, int idUsuarioQueModifica)
        {
            if (producto == null) throw new ArgumentNullException(nameof(producto));
            if (producto.IdProducto <= 0) return "ID de producto inválido para modificar.";
            // ... (otras validaciones de producto y idUsuarioQueModifica) ...
            try
            {
                var productoExistente = _productoRepository.GetById(producto.IdProducto);
                if (productoExistente == null) return $"Producto con ID {producto.IdProducto} no encontrado.";

                var usuario = _usuarioRepository.GetById(idUsuarioQueModifica);
                if (usuario == null) return "Usuario que modifica no encontrado.";

                if (usuario is Vendedor vendedor)
                {
                    if (productoExistente.VendedorId != vendedor.IdVendedor) return "No tiene permiso para modificar este producto (no es el propietario).";
                }
                else if (!(usuario is Administrador))
                {
                    return "El usuario no tiene permisos para modificar productos.";
                }
                // Si es Admin, puede modificar cualquier producto.

                // Actualizar campos del productoExistente con los de producto
                productoExistente.Nombre = producto.Nombre;
                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.Precio = producto.Precio;
                productoExistente.UnidadMedidaId = producto.UnidadMedidaId;
                productoExistente.CategoriaId = producto.CategoriaId;
                productoExistente.Stock = producto.Stock;
                productoExistente.Activo = producto.Activo; // Permitir que el admin/vendedor cambie el estado
                productoExistente.FechaActualizacionStock = DateTime.Now;
                // El VendedorId no debería cambiar aquí a menos que sea una lógica específica de reasignación por admin.

                bool actualizado = _productoRepository.Update(productoExistente);
                return actualizado ?
                       $"Producto '{producto.Nombre}' modificado exitosamente." :
                       "Error al modificar el producto.";
            }
            catch (Exception ex) { return $"Error al modificar producto: {ex.Message}"; }
        }
        public string CambiarEstadoActividadProducto(int idProducto, bool activo, int idUsuarioQueModifica)
        {
            // ... (lógica similar a ModificarProducto para permisos y obtención de producto) ...
            try
            {
                var productoExistente = _productoRepository.GetById(idProducto);
                if (productoExistente == null) return $"Producto con ID {idProducto} no encontrado.";

                var usuario = _usuarioRepository.GetById(idUsuarioQueModifica);
                if (usuario == null) return "Usuario que modifica no encontrado.";

                if (usuario is Vendedor vendedor)
                {
                    if (productoExistente.VendedorId != vendedor.IdVendedor)
                        return "No tiene permiso para cambiar el estado de este producto.";
                }
                else if (!(usuario is Administrador))
                {
                    return "El usuario no tiene permisos para cambiar el estado de productos.";
                }

                productoExistente.Activo = activo;
                productoExistente.FechaActualizacionStock = DateTime.Now; // Actualizar fecha
                bool actualizado = _productoRepository.Update(productoExistente);
                string accion = activo ? "reactivado" : "inactivado";
                return actualizado ? $"Producto ID {idProducto} {accion} exitosamente." : $"Error al {accion} el producto.";
            }
            catch (Exception ex) { return $"Error al cambiar estado del producto: {ex.Message}"; }
        }
        public string AjustarStock(int idProducto, int cantidadAjuste, string motivo, bool esIncremento, int idUsuarioQueAjusta)
        {
            // ... (lógica similar para permisos y obtención de producto) ...
            try
            {
                var producto = _productoRepository.GetById(idProducto);
                if (producto == null) return $"Producto con ID {idProducto} no encontrado.";

                var usuario = _usuarioRepository.GetById(idUsuarioQueAjusta);
                if (usuario == null) return "Usuario que ajusta no encontrado.";

                if (usuario is Vendedor vendedor)
                {
                    if (producto.VendedorId != vendedor.IdVendedor)
                        return "No tiene permiso para ajustar stock de este producto.";
                }
                else if (!(usuario is Administrador))
                {
                    return "El usuario no tiene permisos para ajustar stock.";
                }

                bool resultado;
                if (esIncremento)
                {
                    resultado = _productoRepository.IncrementarStock(idProducto, cantidadAjuste);
                }
                else
                {
                    if (producto.Stock < cantidadAjuste)
                    {
                        return $"Stock insuficiente para la merma. Stock actual: {producto.Stock}, Merma solicitada: {cantidadAjuste}.";
                    }
                    resultado = _productoRepository.AjustarStockPorMerma(idProducto, cantidadAjuste, motivo);
                }
                return resultado ? $"Stock del producto ID {idProducto} ajustado." : "Error al ajustar el stock.";
            }
            catch (Exception ex) { return $"Error al ajustar stock: {ex.Message}"; }
        }
    }
}
