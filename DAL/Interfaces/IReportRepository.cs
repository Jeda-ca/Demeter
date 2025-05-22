using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IReporteRepository : IGenericRepository<Reporte>
    {
        // Para registrar la metadata de los reportes generados.
        // Podría tener métodos para buscar reportes por tipo, fecha, etc.
        IEnumerable<Reporte> GetByTipoReporte(int tipoReporteId);
        IEnumerable<Reporte> GetByAdministradorAndDateRange(int administradorId, DateTime startDate, DateTime endDate);
    }
}
