using System;

namespace RinconGuatemaltecoApp.Models
{
    public class Devolucion
    {
        public int DevolucionID { get; set; }
        public int VentaID { get; set; }
        public int ProductoID { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int Cantidad { get; set; }
        public string Motivo { get; set; }

        public Venta Venta { get; set; }  // Relación con Venta
        public Producto Producto { get; set; }  // Relación con Producto
    }
}
