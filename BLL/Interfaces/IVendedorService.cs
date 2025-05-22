using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IVendedorService
    {
        IEnumerable<Vendedor> ObtenerTodosLosVendedores();
        Vendedor ObtenerVendedorPorId(int idVendedor);
        Vendedor ObtenerVendedorPorCodigo(string codigoVendedor);
        IEnumerable<Vendedor> BuscarVendedoresPorNombreOApellido(string searchTerm);
        Vendedor ObtenerVendedorPorDocumento(int tipoDocumentoId, string numeroDocumento);
        string ModificarVendedor(Vendedor vendedor); // El admin modifica
        string CambiarEstadoActividadVendedor(int idVendedor, bool estaActivo); // Para "eliminar" 
    }
}
