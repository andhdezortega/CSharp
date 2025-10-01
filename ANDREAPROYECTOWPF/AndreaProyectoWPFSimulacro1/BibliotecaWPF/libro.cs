namespace BibliotecaWPF
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int Anio { get; set; }
        public string Genero { get; set; } = string.Empty;
    }
}
