using System;
using System.Collections.Generic;
using System.Linq;
using Saaloon.Context;
using System.Web;

namespace Saaloon.Models
{
    public class ClaseTema
    {
        public int idTema { get; set; }
        public String Tema { get; set; }
        public String DescripcionTema { get; set; }
        public String FotoTema { get; set; }
        public List<Temario> TemarioClase { get; set; }
        public int IdCurso { get; set; }
        public String NombreCurso { get; set; }

        public int idDocente { get; set; }

        public String NombreDocente { get; set; }
        public String ApellidoDocente { get; set; }
    }
}