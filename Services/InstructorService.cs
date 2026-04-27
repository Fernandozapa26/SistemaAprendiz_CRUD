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
        private readonly List<Instructor> _instructores;

        public InstructorService()
        {
            _instructores = new List<Instructor>
            {
                new Instructor { Id = 1, Nombre = "Juan", Apellido = "Goez", Especialidad = "Software" }
            };

            _fichas = new List<Ficha>
            {
                new Ficha { Id = 1, Codigo = "2827301", Programa = "Análisis y Desarrollo de Software" },
                new Ficha { Id = 2, Codigo = "2827302", Programa = "Programación de Software" }
            };

            _observaciones = new List<ObservacionAcademica>();
        }

        // --- CONSULTA DE FICHAS ---
        public IEnumerable<Ficha> ObtenerFichasPorInstructor(int instructorId)
        {
            return _fichas;
        }

        public Ficha ObtenerFichaPorId(int fichaId)
        {
            return _fichas.FirstOrDefault(f => f.Id == fichaId);
        }

        // --- SEGUIMIENTO ACADÉMICO ---
        public void GuardarObservacion(ObservacionAcademica observacion)
        {
            observacion.Id = _observaciones.Count + 1;
            _observaciones.Add(observacion);
        }

        public IEnumerable<ObservacionAcademica> ObtenerHistorialPorAprendiz(int aprendizId)
        {
            return _observaciones.Where(o => o.AprendizId == aprendizId).ToList();
        }

        // --- NUEVOS MÉTODOS PARA REPORTES SELECCIONABLES ---

        public IEnumerable<Instructor> ObtenerTodos() => _instructores;

        public Instructor ObtenerPorId(int id) => _instructores.FirstOrDefault(i => i.Id == id);

        public ReporteGeneral GenerarReporteGeneral(int instructorId)
        {
            // Implementación básica del reporte
            return new ReporteGeneral { NombreInstructor = "Instructor de Prueba" };
        }
    }
}