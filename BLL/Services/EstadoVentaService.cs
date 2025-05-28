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
    public class EstadoVentaService : IEstadoVentaService
    {
        private readonly IEstadoVentaRepository _estadoVentaRepository;

        public EstadoVentaService()
        {
            _estadoVentaRepository = new EstadoVentaRepository();
        }

        public EstadoVentaService(IEstadoVentaRepository estadoVentaRepository)
        {
            _estadoVentaRepository = estadoVentaRepository ?? throw new ArgumentNullException(nameof(estadoVentaRepository));
        }

        public IEnumerable<EstadoVenta> ObtenerTodos()
        {
            try
            {
                return _estadoVentaRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener todos los estados de venta desde el servicio.", ex);
            }
        }

        public EstadoVenta ObtenerPorId(int id)
        {
            if (id <= 0) return null;
            try
            {
                return _estadoVentaRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener estado de venta por ID {id} desde el servicio.", ex);
            }
        }

        public EstadoVenta ObtenerPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return null;
            try
            {
                return _estadoVentaRepository.GetByName(nombre);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener estado de venta por nombre '{nombre}' desde el servicio.", ex);
            }
        }
    }
}
