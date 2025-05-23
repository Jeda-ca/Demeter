﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime FechaOcurrencia { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public int EstadoId { get; set; }
        public string Observaciones { get; set; } 
        public int ClienteId { get; set; }
        public int VendedorId { get; set; } 
        public EstadoVenta EstadoVenta { get; set; }
        public Cliente Cliente { get; set; }
        public Vendedor Vendedor { get; set; }
        public ICollection<DetalleVenta> DetallesVenta { get; set; }

        public Venta()
        {
            DetallesVenta = new HashSet<DetalleVenta>();
        }
    }
}
