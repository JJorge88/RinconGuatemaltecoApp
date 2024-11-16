namespace RinconGuatemaltecoApp.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int ProveedorID { get; set; }

        public Proveedor Proveedor { get; set; }
    }
}
