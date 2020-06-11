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
        [Required(ErrorMessage = "El Campo Tipo Tarjeta es Requerido")]
        public String Tipotc { get; set; }
        [Required(ErrorMessage = "El Campo Titular es Necesario")]
        public String Nombretc { get; set; }
        [Required(ErrorMessage = "Debe especificar un Banco para la Tarjeta")]
        public String Bancotc { get; set; }
        [Required(ErrorMessage = "Debe introducir un numero de la tarjeta")]
        public String Numerotc { get; set; }
        [Required(ErrorMessage = "Requerido! Este codigo se encuentra en la parte trasera de la tarjeta")]
        public String CCV { get; set; }
        [Required(ErrorMessage = "Introduzca el Mes de vencimiento de la tarjeta")]
        public String Mestc { get; set; }
        [Required(ErrorMessage = "Introduzca el año de vencimiento de la tarjeta")]
        public String Añotc { get; set; }

        public int IdUsuariot { get; set; }
        public int idCurso { get; set; }

    }
}