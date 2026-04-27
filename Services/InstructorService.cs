using SistemaAprendices.Interfaces;
using SistemaAprendices.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAprendices.Services
{
    public class InstructorService : IInstructorService
    {
        // Simulamos la base de datos con listas privadas
        private readonly List<Ficha> _fichas;
        private readonly List<ObservacionAcademica> _observaciones;

        public InstructorService()
        {
            // Inicializamos con datos de prueba
            // Corregido: Usamos 'Programa' y 'Jornada' para coincidir con el modelo Ficha
            _fichas = new List<Ficha>
            {
                new Ficha {
                    Id = 1,
                    Codigo = "2827301",
                    Programa = "Análisis y Desarrollo de Software",
                    Jornada = "Mañana",
                    InstructorResponsable = "Juan Goez"
                },
                new Ficha {
                    Id = 2,
                    Codigo = "2827302",
                    Programa = "Programación de Software",
                    Jornada = "Tarde",
                    InstructorResponsable = "Juan Goez"
                }
            };

            _observaciones = new List<ObservacionAcademica>();
        }

        // 1. CONSULTA DE FICHAS
        public IEnumerable<Ficha> ObtenerFichasPorInstructor(int instructorId)
        {
            return _fichas;
        }

        public Ficha ObtenerFichaPorId(int fichaId)
        {
            return _fichas.FirstOrDefault(f => f.Id == fichaId);
        }

        // 2. SEGUIMIENTO ACADÉMICO
        public void GuardarObservacion(ObservacionAcademica observacion)
        {
            // Simulamos el autoincremento del ID
            observacion.Id = _observaciones.Count + 1;
            _observaciones.Add(observacion);
        }

        public IEnumerable<ObservacionAcademica> ObtenerHistorialPorAprendiz(int aprendizId)
        {
            return _observaciones.Where(o => o.AprendizId == aprendizId).ToList();
        }

        // 3. REPORTES
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
                    // Corregido: Se eliminó la referencia a 'o.Aprendiz.Ficha' que daba error
                    ObservacionesRegistradas = _observaciones.Count(o => o.AprendizId > 0)
                }).ToList()
            };
        }
    }
}