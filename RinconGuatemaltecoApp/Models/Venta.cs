using System;
using System.Collections.Generic;

namespace RinconGuatemaltecoApp.Models
{
    public class Venta
    {
        public int VentaID { get; set; }
        public int ClienteID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public Cliente Cliente { get; set; }  // Relación con Cliente
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
    }
}
