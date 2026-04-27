namespace SistemaAprendices.Models
{
    public class Aprendiz
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ficha { get; set; }
        public string Programa { get; set; }
        public string Estado { get; set; }
    }
}