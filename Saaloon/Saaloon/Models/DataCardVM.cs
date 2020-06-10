using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Saaloon.Models
{
    public class DataCardVM
    {
        public int IdTarjeta { get; set; }
        public String Tipotc { get; set; }
        public String Nombretc { get; set; }
        public String Bancotc { get; set; }
        public String Numerotc { get; set; }
        public String CCV { get; set; }
        public String Mestc { get; set; }
        public String Añotc { get; set; }
        public int IdUsuario { get; set; }

    }
}