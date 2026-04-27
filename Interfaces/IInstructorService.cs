using SistemaAprendices.Models;
using System.Collections.Generic;

namespace SistemaAprendices.Interfaces
{
    public interface IInstructorService
    {
        // --- MÉTODOS ADMINISTRATIVOS (Solo Admin) ---

        /// <summary>
        /// Obtiene la lista de todos los instructores registrados en el sistema.
        /// </summary>
        IEnumerable<Instructor> ObtenerTodos();

        /// <summary>
        /// Obtiene la información detallada de un instructor específico.
        /// </summary>
        Instructor ObtenerPorId(int id);


        // 1. VER APRENDICES ASIGNADOS / CONSULTAR FICHAS
        // Retorna la lista de grupos (fichas) que tiene el instructor
        IEnumerable<Ficha> ObtenerFichasPorInstructor(int instructorId);

        // Retorna los detalles de una ficha específica
        Ficha ObtenerFichaPorId(int fichaId);


        // 2. REGISTRAR OBSERVACIONES ACADÉMICAS / SEGUIMIENTO
        // Método para guardar una nueva anotación en la base de datos
        void GuardarObservacion(ObservacionAcademica observacion);

        // Permite consultar todas las notas o llamados de atención de un aprendiz
        IEnumerable<ObservacionAcademica> ObtenerHistorialPorAprendiz(int aprendizId);


        // 3. VER REPORTES DE SUS GRUPOS
        // Genera un resumen con estadísticas de rendimiento para el instructor
        ReporteGeneral GenerarReporteGeneral(int instructorId);
    }
}