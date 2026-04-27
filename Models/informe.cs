namespace SistemaAprendices.Models
{
    public class Informe
    {
        public int Id { get; set; }
        public string InstructorNombre { get; set; }
        public string Fecha { get; set; }
        public string Asunto { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; } // Ejemplo: Académico, Disciplinario, Felicitación
    }
}
