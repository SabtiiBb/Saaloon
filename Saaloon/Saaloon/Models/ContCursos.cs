using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Saaloon.Context;

namespace Saaloon.Models
{
    public class ContCursos
    {
        public int IdCurso { get; set; }
        public String NombreCurso { get; set; }
        public String DescripcionCurso { get; set; }
        public String Recursos { get; set; }
        public decimal Costo { get; set; }
        public String Videointro { get; set; }

        public int IdDocente { get; set; }
        public String NombreDocente { get; set; }

        public List<Temario> ListaTemario;
    }
}