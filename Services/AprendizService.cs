using SistemaAprendices.Interfaces;
using SistemaAprendices.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAprendices.Services
{
    public class AprendizService : IAprendizService
    {
        private static List<Aprendiz> lista = new List<Aprendiz>();

        public List<Aprendiz> ObtenerTodos()
        {
            return lista;
        }

        public void Guardar(Aprendiz aprendiz)
        {
            aprendiz.Id = lista.Count + 1;
            lista.Add(aprendiz);
        }

        public Aprendiz ObtenerPorId(int id)
        {
            return lista.FirstOrDefault(x => x.Id == id);
        }

        public void Actualizar(Aprendiz aprendiz)
        {
            var actual = ObtenerPorId(aprendiz.Id);

            if (actual != null)
            {
                actual.Documento = aprendiz.Documento;
                actual.Nombre = aprendiz.Nombre;
                actual.Apellido = aprendiz.Apellido;
                actual.Ficha = aprendiz.Ficha;
                actual.Programa = aprendiz.Programa;
                actual.Estado = aprendiz.Estado;
            }
        }

        public void Eliminar(int id)
        {
            var aprendiz = ObtenerPorId(id);

            if (aprendiz != null)
            {
                lista.Remove(aprendiz);
            }
        }
    }
}