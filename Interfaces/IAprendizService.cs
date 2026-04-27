using SistemaAprendices.Models;
using System.Collections.Generic;

namespace SistemaAprendices.Interfaces
{
    public interface IAprendizService
    {
        List<Aprendiz> ObtenerTodos();
        void Guardar(Aprendiz aprendiz);

        Aprendiz ObtenerPorId(int id);
        void Actualizar(Aprendiz aprendiz);
        void Eliminar(int id);
    }
}