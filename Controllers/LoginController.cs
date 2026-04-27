using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SistemaAprendices.Interfaces;

namespace SistemaAprendices.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // Muestra la pantalla de Login
        public IActionResult Index()
        {
            // Si el usuario ya está logueado, lo redirigimos al Home automáticamente
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Rol")))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Ingresar(string usuario, string clave)
        {
            // 1. Intentar validar con el servicio (Base de datos o MockService)
            var user = _loginService.ValidarUsuario(usuario, clave);

            if (user != null)
            {
                HttpContext.Session.SetString("Rol", user.Rol);
                HttpContext.Session.SetString("Nombre", user.NombreUsuario);
                HttpContext.Session.SetString("UsuarioId", user.Id.ToString());
                return RedirectToAction("Index", "Home");
            }

            // 2. Lógica de pruebas (Hardcoded) para diferentes roles

            // Perfil de Administrador
            if (usuario == "admin" && clave == "123")
            {
                HttpContext.Session.SetString("Rol", "Administrador");
                HttpContext.Session.SetString("Nombre", "Admin Sistema");
                HttpContext.Session.SetString("UsuarioId", "1");
                return RedirectToAction("Index", "Home");
            }

            // Perfil de Instructor
            else if (usuario == "instructor" && clave == "123")
            {
                HttpContext.Session.SetString("Rol", "Instructor");
                HttpContext.Session.SetString("Nombre", "Juan Goez");
                HttpContext.Session.SetString("UsuarioId", "50");
                return RedirectToAction("Index", "Home");
            }

            // Perfil de Aprendiz
            else if (usuario == "aprendiz" && clave == "123")
            {
                HttpContext.Session.SetString("Rol", "Aprendiz");
                HttpContext.Session.SetString("Nombre", "Estudiante SENA");
                HttpContext.Session.SetString("UsuarioId", "101"); // ID para filtrar sus reportes luego
                return RedirectToAction("Index", "Home");
            }

            // 3. Si no coincide ninguna credencial
            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View("Index");
        }

        // Método para cerrar sesión
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}