using DAL.Helpers;
using DAL.Interfaces;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        public bool ExistePersonaPorDocumento(int tipoDocumentoId, string numeroDocumento)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "SELECT COUNT(1) FROM persons WHERE document_type_id = @DocumentTypeId AND document_number = @DocumentNumber";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DocumentTypeId", tipoDocumentoId);
                    command.Parameters.AddWithValue("@DocumentNumber", numeroDocumento);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public Persona GetPersonaPorDocumento(int tipoDocumentoId, string numeroDocumento)
        {
            var clienteRepo = new ClienteRepository();
            var cliente = clienteRepo.GetByNumeroDocumento(tipoDocumentoId, numeroDocumento);
            if (cliente != null) return cliente;

            var adminRepo = new AdministradorRepository();
            var admin = adminRepo.GetByNumeroDocumento(tipoDocumentoId, numeroDocumento);
            if (admin != null) return admin;

            var vendedorRepo = new VendedorRepository();
            var vendedor = vendedorRepo.GetByNumeroDocumento(tipoDocumentoId, numeroDocumento);
            if (vendedor != null) return vendedor;

            return null;
        }
    }
}
