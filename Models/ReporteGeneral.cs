using System.Collections.Generic;

namespace SistemaAprendices.Models
{
    public class ReporteGeneral
    {
        public string NombreInstructor { get; set; }
        public int TotalFichasAsignadas { get; set; }
        public int TotalAprendices { get; set; }

        // Lista detallada para la tabla de reportes
        public List<ResumenFicha> DetallePorFicha { get; set; }
    }

    public class ResumenFicha
    {
        public string CodigoFicha { get; set; }
        public int CantidadAprendices { get; set; }
        public int ObservacionesRegistradas { get; set; }
    }
}