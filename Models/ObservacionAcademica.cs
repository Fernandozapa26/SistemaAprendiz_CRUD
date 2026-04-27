using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaAprendices.Models
{
    public class ObservacionAcademica
    {
        [Key]
        public int Id { get; set; }

        public int AprendizId { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El detalle es obligatorio")]
        public string Detalle { get; set; }

        public string Tipo { get; set; } // Académico o Disciplinario

        // Este campo debe coincidir con el de la vista CrearObservacion
        public string InstructorResponsable { get; set; }
    }
}