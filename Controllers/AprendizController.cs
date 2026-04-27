using Microsoft.AspNetCore.Mvc;
using SistemaAprendices.Interfaces;
using SistemaAprendices.Models;

namespace SistemaAprendices.Controllers
{
    public class AprendizController : Controller
    {
        private readonly IAprendizService _aprendizService;

        public AprendizController(IAprendizService aprendizService)
        {
            _aprendizService = aprendizService;
        }

        // LISTAR
        public IActionResult Index()
        {
            var lista = _aprendizService.ObtenerTodos();
            return View(lista);
        }

        // MOSTRAR FORMULARIO CREAR
        public IActionResult Crear()
        {
            return View();
        }

        // GUARDAR NUEVO APRENDIZ
        [HttpPost]
        public IActionResult Crear(Aprendiz aprendiz)
        {
            _aprendizService.Guardar(aprendiz);
            return RedirectToAction("Index");
        }

        // MOSTRAR FORMULARIO EDITAR
        public IActionResult Editar(int id)
        {
            var aprendiz = _aprendizService.ObtenerPorId(id);

            if (aprendiz == null)
            {
                return NotFound();
            }

            return View(aprendiz);
        }

        // ACTUALIZAR DATOS
        [HttpPost]
        public IActionResult Editar(Aprendiz aprendiz)
        {
            _aprendizService.Actualizar(aprendiz);
            return RedirectToAction("Index");
        }

        // ELIMINAR REGISTRO
        public IActionResult Eliminar(int id)
        {
            _aprendizService.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}