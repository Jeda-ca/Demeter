using BLL.Interfaces;
using DAL.Interfaces;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IPersonaRepository _personaRepository;

        public ClienteService(IClienteRepository clienteRepository, IPersonaRepository personaRepository)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _personaRepository = personaRepository ?? throw new ArgumentNullException(nameof(personaRepository));
        }

        public IEnumerable<Cliente> ObtenerTodosLosClientes()
        {
            try
            {
                return _clienteRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener todos los clientes.", ex);
            }
        }

        public Cliente ObtenerClientePorId(int idCliente)
        {
            if (idCliente <= 0) throw new ArgumentException("El ID del cliente debe ser positivo.", nameof(idCliente));
            try
            {
                return _clienteRepository.GetById(idCliente);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener el cliente con ID {idCliente}.", ex);
            }
        }

        public Cliente ObtenerClientePorCodigo(string codigoCliente)
        {
            if (string.IsNullOrWhiteSpace(codigoCliente)) throw new ArgumentException("El código del cliente no puede estar vacío.", nameof(codigoCliente));
            try
            {
                return _clienteRepository.GetByCodigoCliente(codigoCliente);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener el cliente con código {codigoCliente}.", ex);
            }
        }

        public Cliente ObtenerClientePorDocumento(int tipoDocumentoId, string numeroDocumento)
        {
            if (tipoDocumentoId <= 0) throw new ArgumentException("El tipo de documento es inválido.", nameof(tipoDocumentoId));
            if (string.IsNullOrWhiteSpace(numeroDocumento)) throw new ArgumentException("El número de documento no puede estar vacío.", nameof(numeroDocumento));
            try
            {
                return _clienteRepository.GetByNumeroDocumento(tipoDocumentoId, numeroDocumento);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener cliente por documento {tipoDocumentoId}-{numeroDocumento}.", ex);
            }
        }

        public IEnumerable<Cliente> BuscarClientesPorNombreOApellido(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return ObtenerTodosLosClientes();
            try
            {
                return _clienteRepository.SearchByNombreOApellido(searchTerm);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al buscar clientes con el término '{searchTerm}'.", ex);
            }
        }

        public string RegistrarOActualizarCliente(Cliente cliente, bool esNuevo)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));

            if (string.IsNullOrWhiteSpace(cliente.Nombre)) return "El nombre del cliente es requerido.";
            if (string.IsNullOrWhiteSpace(cliente.Apellido)) return "El apellido del cliente es requerido.";
            if (cliente.TipoDocumentoId <= 0) return "El tipo de documento es requerido.";
            if (string.IsNullOrWhiteSpace(cliente.NumeroDocumento)) return "El número de documento es requerido.";
            if (esNuevo && string.IsNullOrWhiteSpace(cliente.CodigoCliente)) return "El código de cliente es requerido para nuevos clientes.";
            if (!string.IsNullOrWhiteSpace(cliente.Correo) && !IsValidEmail(cliente.Correo)) return "El formato del correo electrónico no es válido.";

            try
            {
                if (esNuevo)
                {
                    if (_personaRepository.ExistePersonaPorDocumento(cliente.TipoDocumentoId, cliente.NumeroDocumento))
                    {
                        return $"Ya existe una persona registrada con el documento {cliente.NumeroDocumento}.";
                    }
                    if (_clienteRepository.GetByCodigoCliente(cliente.CodigoCliente) != null)
                    {
                        return $"El código de cliente '{cliente.CodigoCliente}' ya está en uso.";
                    }

                    cliente.FechaRegistro = DateTime.Now;
                    cliente.Activo = true;
                    var clienteAgregado = _clienteRepository.Add(cliente);
                    return clienteAgregado != null && clienteAgregado.IdCliente > 0 ?
                           $"Cliente '{cliente.Nombre} {cliente.Apellido}' registrado exitosamente."
                           : "Error al registrar el cliente.";
                }
                else
                {
                    if (cliente.IdCliente <= 0 || cliente.IdPersona <= 0) return "IDs de cliente y persona son necesarios para actualizar.";

                    var clienteExistentePorDocumento = _clienteRepository.GetByNumeroDocumento(cliente.TipoDocumentoId, cliente.NumeroDocumento);
                    if (clienteExistentePorDocumento != null && clienteExistentePorDocumento.IdCliente != cliente.IdCliente)
                    {
                        return $"El documento {cliente.NumeroDocumento} ya pertenece a otro cliente.";
                    }
                    var clienteExistentePorCodigo = _clienteRepository.GetByCodigoCliente(cliente.CodigoCliente);
                    if (clienteExistentePorCodigo != null && clienteExistentePorCodigo.IdCliente != cliente.IdCliente)
                    {
                        return $"El código de cliente '{cliente.CodigoCliente}' ya pertenece a otro cliente.";
                    }

                    bool actualizado = _clienteRepository.Update(cliente);
                    return actualizado ?
                           $"Cliente '{cliente.Nombre} {cliente.Apellido}' actualizado exitosamente."
                           : "Error al actualizar el cliente.";
                }
            }
            catch (DataException dex)
            {
                return $"Error de base de datos: {dex.Message}";
            }
            catch (Exception ex)
            {
                return $"Error inesperado: {ex.Message}";
            }
        }

        public bool CambiarEstadoActividadCliente(int idCliente, bool nuevoEstadoActivo)
        {
            if (idCliente <= 0) throw new ArgumentException("ID de cliente inválido.", nameof(idCliente));
            try
            {
                var cliente = _clienteRepository.GetById(idCliente);
                if (cliente == null) return false;

                cliente.Activo = nuevoEstadoActivo;
                return _clienteRepository.Update(cliente);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al cambiar estado de actividad del cliente ID {idCliente}.", ex);
            }
        }

        private bool IsValidEmail(string email)
        {
            try { var addr = new System.Net.Mail.MailAddress(email); return addr.Address == email; }
            catch { return false; }
        }
    }
}
