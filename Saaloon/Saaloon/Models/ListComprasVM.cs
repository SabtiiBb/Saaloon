using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saaloon.Models
{
    public class ListComprasVM
    {
        public String NombreCurso  { get; set; }

        public decimal Costo { get; set; }

        public String NombreTarjeta { get; set; }
        public String NumeroTarjeta { get; set; }
        public String Fecha { get; set; }
        public String idcompra { get; set; }
    }
}