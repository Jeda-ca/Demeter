using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoriaProductoService : ICategoriaProductoService
    {
        private readonly ICategoriaProductoRepository _categoriaRepository;

        public CategoriaProductoService()
        {
            _categoriaRepository = new CategoriaProductoRepository();
        }

        public CategoriaProductoService(ICategoriaProductoRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository ?? throw new ArgumentNullException(nameof(categoriaRepository));
        }

        public IEnumerable<CategoriaProducto> ObtenerTodas()
        {
            try
            {
                return _categoriaRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener todas las categorías de producto desde el servicio.", ex);
            }
        }

        public CategoriaProducto ObtenerPorId(int id)
        {
            if (id <= 0) return null;
            try
            {
                return _categoriaRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener categoría por ID {id}.", ex);
            }
        }
        public CategoriaProducto ObtenerPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return null;
            try
            {
                return _categoriaRepository.GetByName(nombre);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener categoría por nombre '{nombre}'.", ex);
            }
        }

        public string AgregarCategoria(CategoriaProducto categoria)
        {
            if (categoria == null || string.IsNullOrWhiteSpace(categoria.Nombre))
            {
                return "El nombre de la categoría no puede estar vacío.";
            }
            try
            {
                var existente = _categoriaRepository.GetByName(categoria.Nombre);
                if (existente != null)
                {
                    return $"La categoría '{categoria.Nombre}' ya existe.";
                }
                var agregada = _categoriaRepository.Add(categoria);
                return agregada != null && agregada.IdCategoria > 0 ? $"Categoría '{agregada.Nombre}' agregada exitosamente." : "No se pudo agregar la categoría.";
            }
            catch (DataException dex)
            {
                return $"Error de base de datos al agregar categoría: {dex.Message}";
            }
            catch (Exception ex)
            {
                return $"Error inesperado al agregar categoría: {ex.Message}";
            }
        }

        public string ActualizarCategoria(CategoriaProducto categoria)
        {
            if (categoria == null || categoria.IdCategoria <= 0 || string.IsNullOrWhiteSpace(categoria.Nombre))
            {
                return "Datos inválidos para actualizar la categoría.";
            }
            try
            {
                var existenteConMismoNombre = _categoriaRepository.GetByName(categoria.Nombre);
                if (existenteConMismoNombre != null && existenteConMismoNombre.IdCategoria != categoria.IdCategoria)
                {
                    return $"Ya existe otra categoría con el nombre '{categoria.Nombre}'.";
                }

                bool actualizado = _categoriaRepository.Update(categoria);
                return actualizado ? $"Categoría '{categoria.Nombre}' actualizada exitosamente." : "No se pudo actualizar la categoría.";
            }
            catch (DataException dex)
            {
                return $"Error de base de datos al actualizar categoría: {dex.Message}";
            }
            catch (Exception ex)
            {
                return $"Error inesperado al actualizar categoría: {ex.Message}";
            }
        }

        public string EliminarCategoria(int idCategoria)
        {
            if (idCategoria <= 0)
            {
                return "ID de categoría inválido.";
            }
            try
            {
                bool eliminado = _categoriaRepository.Delete(idCategoria);
                return eliminado ? "Categoría eliminada exitosamente." : "No se pudo eliminar la categoría. Es posible que esté en uso o no exista.";
            }
            catch (DataException dex)
            {
                return $"Error de base de datos al eliminar categoría: {dex.Message}";
            }
            catch (Exception ex)
            {
                return $"Error inesperado al eliminar categoría: {ex.Message}";
            }
        }
    }
}
