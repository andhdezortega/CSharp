namespace AndreaProyectoWPF
{
    public class Producto
    {
        public int Id_producto { get; set; } 
        public string Nombre { get; set; } = string.Empty;
        public double Precio { get; set; } 
        public int Stock { get; set; } 
        public string Fecha_creacion { get; set; } = string.Empty;
        public bool Disponible { get; set; } 
        public string Categoria { get; set; } = string.Empty;

    
    }
}