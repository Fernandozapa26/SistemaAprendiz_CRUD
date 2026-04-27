using Microsoft.AspNetCore.Mvc;
using SistemaAprendices.Interfaces;
using SistemaAprendices.Models;
using System.Collections.Generic;

namespace SistemaAprendices.Controllers
{
    public class InstructorController : Controller
    {
        // Inyectamos las interfaces necesarias
        private readonly IInstructorService _instructorService;
        private readonly IAprendizService _aprendizService;

        public InstructorController(IInstructorService instructorService, IAprendizService aprendizService)
        {
            _instructorService = instructorService;
            _aprendizService = aprendizService;
        }

        // 1. LISTAR FICHAS ASIGNADAS
        // Acción principal del instructor para ver sus grupos
        public IActionResult MisFichas()
        {
            // Por ahora usamos un ID fijo (ej: 1), luego vendrá del Login
            int instructorId = 1;
            var fichas = _instructorService.ObtenerFichasPorInstructor(instructorId);
            return View(fichas);
        }

        // 2. VER APRENDICES DE UNA FICHA
        // Muestra la lista de aprendices filtrada por el ID de la ficha seleccionada
        public IActionResult VerAprendices(int fichaId)
        {
            // Usamos el servicio de aprendiz para obtener los alumnos de esa ficha
            var lista = _aprendizService.ObtenerPorFicha(fichaId);
            return View(lista);
        }

        // 3. REGISTRAR OBSERVACIÓN (Vista - GET)
        // Muestra el formulario para crear una nota académica o disciplinaria
        public IActionResult CrearObservacion(int aprendizId)
        {
            var aprendiz = _aprendizService.ObtenerPorId(aprendizId);

            if (aprendiz == null)
            {
                return NotFound();
            }

            // Pasamos el nombre al ViewBag para mostrarlo en el título del formulario
            ViewBag.NombreAprendiz = $"{aprendiz.Nombre} {aprendiz.Apellido}";

            // Preparamos el modelo con el ID del aprendiz vinculado
            var nuevaObservacion = new ObservacionAcademica
            {
                AprendizId = aprendizId
            };

            return View(nuevaObservacion);
        }

        // 4. GUARDAR OBSERVACIÓN (POST)
        // Recibe los datos del formulario y los guarda
        [HttpPost]
        public IActionResult CrearObservacion(ObservacionAcademica observacion)
        {
            if (ModelState.IsValid)
            {
                _instructorService.GuardarObservacion(observacion);

                // Después de guardar, lo enviamos a ver el historial de ese aprendiz
                return RedirectToAction("SeguimientoDisciplinario", new { id = observacion.AprendizId });
            }

            return View(observacion);
        }

        // 5. CONSULTAR HISTORIAL / SEGUIMIENTO DISCIPLINARIO
        // Muestra todas las observaciones registradas de un aprendiz
        public IActionResult SeguimientoDisciplinario(int id)
        {
            var historial = _instructorService.ObtenerHistorialPorAprendiz(id);
            return View(historial);
        }

        // 6. REPORTES DE GRUPOS
        // Muestra estadísticas generales de las fichas del instructor
        public IActionResult Reportes()
        {
            int instructorId = 1;
            var reporte = _instructorService.GenerarReporteGeneral(instructorId);
            return View(reporte);
        }
    }
}