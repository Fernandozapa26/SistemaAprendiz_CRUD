namespace SistemaAprendices.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        // El área a la que pertenece (ej: Sistemas, Gastronomía, Salud)
        public string Area { get; set; }

        // Para diferenciar si es de planta o contratista
        public string TipoContrato { get; set; }

        // Estado del instructor en el sistema (Activo/Inactivo)
        public string Estado { get; set; }

        // El correo institucional para temas de notificaciones o login
        public string Email { get; set; }

        // Una lista de las fichas que este instructor tiene asignadas
        // Esto te permitirá hacer algo como: instructor.FichasAsignadas
        public List<string> FichasAsignadas { get; set; }

        public string Especialidad { get; set; }
    }
}