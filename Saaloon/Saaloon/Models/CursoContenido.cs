using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Saaloon.Context;

namespace Saaloon.Models
{
    public class CursoContenido
    {
        public int IdCurso { get; set; }
        public String NombreCurso { get; set; }
        public String Descripcion { get; set; }
        public String RecursosCurso { get; set; }
        public decimal CostoCurso { get; set; }
        public String Foto { get; set; }
        public String Videointro { get; set; }

        //public int IdTemario { get; set; }
        //public String Tema { get; set; }
        //public String DescripcionTema { get; set; }
        //public String FotoTema { get; set; }
        public List<Temario> TemarioM{ get; set; }

        public int IdDocente { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
    }
}