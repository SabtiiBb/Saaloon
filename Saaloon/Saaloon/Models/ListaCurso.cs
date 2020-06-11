using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Saaloon.Context;
using System.ComponentModel;

namespace Saaloon.Models
{
    public class ListaCurso
    {
        public int IdCurso { get; set; }
        [DisplayName("TEMARIO")]
        public String NombreCurso { get; set; }
        public List<Temario> TemarioM { get; set; }
        public int IdDocente { get; set; }
    }
}