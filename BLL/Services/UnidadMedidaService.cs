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
    public class UnidadMedidaService : IUnidadMedidaService
    {
        private readonly IUnidadMedidaRepository _unidadMedidaRepository;

        public UnidadMedidaService()
        {
            _unidadMedidaRepository = new UnidadMedidaRepository();
        }

        public UnidadMedidaService(IUnidadMedidaRepository unidadMedidaRepository)
        {
            _unidadMedidaRepository = unidadMedidaRepository ?? throw new ArgumentNullException(nameof(unidadMedidaRepository));
        }

        public IEnumerable<UnidadMedida> ObtenerTodas()
        {
            try
            {
                return _unidadMedidaRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener todas las unidades de medida desde el servicio.", ex);
            }
        }

        public UnidadMedida ObtenerPorId(int id)
        {
            if (id <= 0) return null;
            try
            {
                return _unidadMedidaRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener unidad de medida por ID {id}.", ex);
            }
        }
    }
}
