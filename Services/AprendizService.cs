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

        public IEnumerable<Aprendiz> ObtenerPorFicha(int fichaId)
        {
            string codigoFicha = fichaId.ToString();
            return lista.Where(x => x.Ficha == codigoFicha).ToList();
        }

        // --- NUEVOS MÉTODOS PARA EL PERFIL DE APRENDIZ ---

        public IEnumerable<Ficha> ObtenerMisCursos(string aprendizId)
        {
            // Simulamos que el aprendiz está en dos fichas específicas
            return new List<Ficha>
            {
                new Ficha { Id = 1, NumeroFicha = "2670687", Programa = "Análisis y Desarrollo de Software" },
                new Ficha { Id = 2, NumeroFicha = "2670688", Programa = "Inglés Técnico Nivel 1" }
            };
        }

        public IEnumerable<Informe> ObtenerMisInformes(string aprendizId)
        {
            // Simulamos reportes que los instructores le han hecho a este aprendiz
            return new List<Informe>
            {
                new Informe
                {
                    Id = 101,
                    InstructorNombre = "Juan Goez",
                    Fecha = "2026-04-20",
                    Asunto = "Excelente Participación",
                    Descripcion = "El aprendiz entregó el login funcional antes de la fecha límite.",
                    Tipo = "Felicitación"
                },
                new Informe
                {
                    Id = 102,
                    InstructorNombre = "Maria Lopez",
                    Fecha = "2026-04-25",
                    Asunto = "Observación Académica",
                    Descripcion = "Se recomienda reforzar el manejo de Entity Framework.",
                    Tipo = "Académico"
                }
            };
        }
    }
}