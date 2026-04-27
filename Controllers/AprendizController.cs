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

        // ACTUALIZADO: Ahora muestra la lista de Fichas en lugar de todos los aprendices
        public IActionResult Index()
        {
            // Seguridad: Solo el admin puede ver la lista global
            var rol = HttpContext.Session.GetString("Rol")?.ToLower() ?? "";
            if (!rol.Contains("admin")) return RedirectToAction("Index", "Home");

            // Obtenemos las fichas disponibles (usando el método del servicio)
            var fichas = _aprendizService.ObtenerMisCursos("");
            return View("Fichas", fichas);
        }

        // NUEVO: Muestra los aprendices de una ficha específica
        public IActionResult VerPorFicha(int id)
        {
            var rol = HttpContext.Session.GetString("Rol")?.ToLower() ?? "";
            if (!rol.Contains("admin")) return RedirectToAction("Index", "Home");

            var aprendices = _aprendizService.ObtenerPorFicha(id);
            ViewBag.FichaId = id; // Para mostrar el número en la vista

            return View("ListaPorFicha", aprendices);
        }

        public IActionResult Crear() => View();

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
            if (aprendiz == null) return NotFound();
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