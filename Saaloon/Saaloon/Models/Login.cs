using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saaloon.Models
{
    public class Login
    {
        [Required(ErrorMessage ="<font color= 'red'> No puede dejar este espacio en blanco </font>")]
        [Display(Name = "Usuario")]
        public String Usuario { get; set; }

        [StringLength (100, ErrorMessage ="el número de caracteres de {0} debe ser al menos {2}. </font>", MinimumLength =3)]
        [Required(ErrorMessage = "<font color= 'red'> No puede dejar este espacio en blanco </font>")]
        [Display(Name = "Contraseña")]
        public String contraseña { get; set; }

        public String correo { get; set; }
    }
}