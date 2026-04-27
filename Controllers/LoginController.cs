using Microsoft.AspNetCore.Mvc;  //permite usar controller, view
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ingresar(string usuario, string clave)
        {
            var user = _loginService.ValidarUsuario(usuario, clave);

            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View("Index");
        }
    }
}