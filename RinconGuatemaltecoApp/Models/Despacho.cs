using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RinconGuatemaltecoApp.Models
{
    public class Despacho
    {
        [Key]
        public int DespachoID { get; set; }

        // Otras propiedades del despacho
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        // Relación con Cliente
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }

        // Relación con DetalleDespacho
        public ICollection<DetalleDespacho> DetalleDespachos { get; set; }
    }
}

