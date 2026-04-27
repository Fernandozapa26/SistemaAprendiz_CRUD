using SistemaAprendices.Interfaces;
using SistemaAprendices.Models;

namespace SistemaAprendices.Services
{
    public class LoginService : ILoginService  //La clase implementa la interfaz. Valida usuario sin ensuciar controladores.
    {
        public Usuario ValidarUsuario(string usuario, string clave)
        {
            if (usuario == "admin" && clave == "123456")
            {
                return new Usuario
                {
                    Id = 1,
                    NombreUsuario = "admin",
                    Rol = "Administrador"
                };
            }

            return null;
        }
    }
}