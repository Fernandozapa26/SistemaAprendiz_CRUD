using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaAprendices.Models
{
    public class Ficha
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El código de la ficha es obligatorio")]
        [Display(Name = "Número de Ficha")]
        public string Codigo { get; set; }


        [Required(ErrorMessage = "El programa de formación es obligatorio")]
        public string Programa { get; set; }

        
        public string Jornada { get; set; }

        public string NumeroFicha { get; set; }


        public string Estado { get; set; }

        // Relación: Una ficha contiene muchos aprendices
        public List<Aprendiz> Aprendices { get; set; }

        public string InstructorResponsable { get; set; }
    }
}