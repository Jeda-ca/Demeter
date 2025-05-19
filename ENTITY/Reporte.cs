using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Reporte
    {
        public int IdReporte { get; set; }
        public int AdministradorId { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public int TipoReporteId { get; set; }
        public DateTime? InicioPeriodo { get; set; } // Nullable
        public DateTime? FinPeriodo { get; set; }    // Nullable
        public int? FiltroVendedorId { get; set; }   // Nullable FK
        public int? FiltroClienteId { get; set; }    // Nullable FK
        public Administrador Administrador { get; set; }
        public TipoReporte TipoReporte { get; set; }
        public Vendedor VendedorFiltrado { get; set; } // Puede ser null si FiltroVendedorId es null
        public Cliente ClienteFiltrado { get; set; }   // Puede ser null si FiltroClienteId es null
    }
}
