using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IClienteService
    {
        IEnumerable<Cliente> ObtenerTodosLosClientes();
        Cliente ObtenerClientePorId(int idCliente);
        Cliente ObtenerClientePorCodigo(string codigoCliente);
        Cliente ObtenerClientePorDocumento(int tipoDocumentoId, string numeroDocumento);
        IEnumerable<Cliente> BuscarClientesPorNombreOApellido(string searchTerm);
        string RegistrarOActualizarCliente(Cliente cliente, bool esNuevo);
        bool CambiarEstadoActividadCliente(int idCliente, bool estaActivo);
    }
}

