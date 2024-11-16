using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RinconGuatemaltecoApp.Models
{
    public class DetalleDespacho
    {
        [Key]
        public int DetalleID { get; set; }

        public int DespachoID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

        [ForeignKey("DespachoID")]
        public Despacho Despacho { get; set; }

        [ForeignKey("ProductoID")]
        public Producto Producto { get; set; }
    }
}

