using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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

        // --- MÉTODOS ADMINISTRATIVOS (Solo Admin) ---

        public IActionResult Index()
        {
            // Seguridad: Solo el admin puede ver la lista global
            var rol = HttpContext.Session.GetString("Rol")?.ToLower() ?? "";
            if (!rol.Contains("admin")) return RedirectToAction("Index", "Home");

            var lista = _aprendizService.ObtenerTodos();
            return View(lista);
        }

        public IActionResult Crear() => View();

        [HttpPost]
        public IActionResult Crear(Aprendiz aprendiz)
        {
            _aprendizService.Guardar(aprendiz);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var aprendiz = _aprendizService.ObtenerPorId(id);
            if (aprendiz == null) return NotFound();
            return View(aprendiz);
        }

        [HttpPost]
        public IActionResult Editar(Aprendiz aprendiz)
        {
            _aprendizService.Actualizar(aprendiz);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            _aprendizService.Eliminar(id);
            return RedirectToAction("Index");
        }


        // --- MÉTODOS PARA EL PERFIL DE APRENDIZ (Solo Aprendiz) ---

        public IActionResult MisCursos()
        {
            var rol = HttpContext.Session.GetString("Rol")?.ToLower() ?? "";
            if (!rol.Contains("aprendiz")) return RedirectToAction("Index", "Login");

            var aprendizId = HttpContext.Session.GetString("UsuarioId");
            var misCursos = _aprendizService.ObtenerMisCursos(aprendizId);

            return View(misCursos);
        }

        public IActionResult MisReportes()
        {
            var rol = HttpContext.Session.GetString("Rol")?.ToLower() ?? "";
            if (!rol.Contains("aprendiz")) return RedirectToAction("Index", "Login");

            var aprendizId = HttpContext.Session.GetString("UsuarioId");
            var misReportes = _aprendizService.ObtenerMisInformes(aprendizId);

            return View(misReportes);
        }
    }
}