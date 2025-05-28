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
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;

        public RolService()
        {
            _rolRepository = new RolRepository(); // El servicio instancia su propio repositorio
        }

        // Constructor para inyección de dependencias (útil para pruebas)
        public RolService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository ?? throw new ArgumentNullException(nameof(rolRepository));
        }

        public IEnumerable<Rol> ObtenerTodosLosRoles()
        {
            try
            {
                return _rolRepository.GetAll();
            }
            catch (Exception ex)
            {
                // Considera loggear el error
                throw new ApplicationException("Error al obtener todos los roles desde el servicio.", ex);
            }
        }

        public Rol ObtenerRolPorId(int idRol)
        {
            if (idRol <= 0) return null;
            try
            {
                return _rolRepository.GetById(idRol);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener rol por ID {idRol} desde el servicio.", ex);
            }
        }
        public Rol ObtenerRolPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return null;
            try
            {
                return _rolRepository.GetByName(nombre);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener rol por nombre '{nombre}' desde el servicio.", ex);
            }
        }
    }
}
