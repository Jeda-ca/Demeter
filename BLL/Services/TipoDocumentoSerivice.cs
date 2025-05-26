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
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly ITipoDocumentoRepository _tipoDocumentoRepository;

        public TipoDocumentoService()
        {
            _tipoDocumentoRepository = new TipoDocumentoRepository();
        }

        public TipoDocumentoService(ITipoDocumentoRepository tipoDocumentoRepository)
        {
            _tipoDocumentoRepository = tipoDocumentoRepository ?? throw new ArgumentNullException(nameof(tipoDocumentoRepository));
        }

        public IEnumerable<TipoDocumento> ObtenerTodos()
        {
            try
            {
                return _tipoDocumentoRepository.GetAll();
            }
            catch (Exception ex)
            {
                // Aquí podrías loggear el error si tienes un sistema de logging
                throw new ApplicationException("Error al obtener todos los tipos de documento desde el servicio.", ex);
            }
        }

        public TipoDocumento ObtenerPorId(int id)
        {
            if (id <= 0) return null; // O lanzar ArgumentException
            try
            {
                return _tipoDocumentoRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener tipo de documento por ID {id} desde el servicio.", ex);
            }
        }
    }
}
