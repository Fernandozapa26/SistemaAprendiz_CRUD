using SistemaAprendices.Models;

namespace SistemaAprendices.Interfaces
{
    public interface ILoginService
    {
        Usuario ValidarUsuario(string usuario, string clave);
    }
}