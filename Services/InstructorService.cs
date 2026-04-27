using SistemaAprendices.Interfaces;
using SistemaAprendices.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAprendices.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly List<Ficha> _fichas;
        private readonly List<ObservacionAcademica> _observaciones;

        // NUEVO: Lista de instructores para que el Admin los vea
        private readonly List<Instructor> _instructores;

        public InstructorService()
        {
            // Datos de prueba para Instructores
            _instructores = new List<Instructor>
            {
                new Instructor { Id = 1, Nombre = "Juan", Apellido = "Goez", Especialidad = "Software" },
                new Instructor { Id = 2, Nombre = "Maria", Apellido = "Lopez", Especialidad = "Redes" }
            };

            _fichas = new List<Ficha>
            {
                new Ficha { Id = 1, Codigo = "2827301", Programa = "Análisis y Desarrollo de Software", Jornada = "Mañana", InstructorResponsable = "Juan Goez" },
                new Ficha { Id = 2, Codigo = "2827302", Programa = "Programación de Software", Jornada = "Tarde", InstructorResponsable = "Juan Goez" }
            };

            _observaciones = new List<ObservacionAcademica>();
        }

        // --- SOLUCIÓN A ERRORES CS0535 (Implementación de Interfaz) ---

        public IEnumerable<Instructor> ObtenerTodos()
        {
            return _instructores;
        }

        public Instructor ObtenerPorId(int id)
        {
            return _instructores.FirstOrDefault(i => i.Id == id);
        }

        // --- MÉTODOS QUE YA TENÍAS (Mantenemos tus comentarios) ---

        public IEnumerable<Ficha> ObtenerFichasPorInstructor(int instructorId)
        {
            // Por ahora devolvemos todas para la prueba del Admin
            return _fichas;
        }

        public Ficha ObtenerFichaPorId(int fichaId)
        {
            return _fichas.FirstOrDefault(f => f.Id == fichaId);
        }

        public void GuardarObservacion(ObservacionAcademica observacion)
        {
            observacion.Id = _observaciones.Count + 1;
            _observaciones.Add(observacion);
        }

        public IEnumerable<ObservacionAcademica> ObtenerHistorialPorAprendiz(int aprendizId)
        {
            return _observaciones.Where(o => o.AprendizId == aprendizId).ToList();
        }

        public ReporteGeneral GenerarReporteGeneral(int instructorId)
        {
            return new ReporteGeneral
            {
                NombreInstructor = "Juan Goez",
                TotalFichasAsignadas = _fichas.Count,
                TotalAprendices = 50,
                DetallePorFicha = _fichas.Select(f => new ResumenFicha
                {
                    CodigoFicha = f.Codigo,
                    CantidadAprendices = 25,
                    ObservacionesRegistradas = _observaciones.Count(o => o.AprendizId > 0)
                }).ToList()
            };
        }
    }
}