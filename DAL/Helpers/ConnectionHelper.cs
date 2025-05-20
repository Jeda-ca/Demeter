using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL.Helpers
{
    public static class ConnectionHelper
    {
        private static string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DemeterDBConnection"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                // Este es un punto crítico. En un entorno real, no deberías tener un fallback con credenciales.
                // Deberías lanzar una excepción clara si la cadena de conexión no está configurada.
                throw new ConfigurationErrorsException(
                    "La cadena de conexión 'DemeterDBConnection' no se encontró o está vacía en el archivo de configuración del proyecto de inicio.");
                
                // Ejemplo de fallback SOLO para desarrollo local si no quieres usar App.config al principio:
                // return "Server=localhost;Database=DEMETER_DB;Integrated Security=True;"; 
            }
            return connectionString;
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
        
    }
}
