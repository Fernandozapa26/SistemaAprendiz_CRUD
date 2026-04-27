using SistemaAprendices.Models;
using System.Collections.Generic;

namespace SistemaAprendices.Interfaces
{
    public interface IAprendizService
    {
        // --- Gestión Administrativa (Para el Admin) ---
        List<Aprendiz> ObtenerTodos();
        void Guardar(Aprendiz aprendiz);
        Aprendiz ObtenerPorId(int id);
        void Actualizar(Aprendiz aprendiz);
        void Eliminar(int id);
        IEnumerable<Aprendiz> ObtenerPorFicha(int fichaId);

        // --- Gestión de Usuario (Para el Aprendiz logueado) ---

        /// <summary>
        /// Obtiene los cursos o fichas en los que el aprendiz está matriculado.
        /// </summary>
        IEnumerable<Ficha> ObtenerMisCursos(string aprendizId);

        /// <summary>
        /// Obtiene los reportes, novedades u observaciones realizadas por instructores.
        /// </summary>
        IEnumerable<Informe> ObtenerMisInformes(string aprendizId);
    }
}