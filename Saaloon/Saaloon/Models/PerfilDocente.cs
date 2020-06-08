﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Saaloon.Models
{
    public class PerfilDocente
    {
        public int IdDocente { get; set; }
        public string Usuario1 { get; set; }
        public string correo { get; set; }
        [Required(ErrorMessage = "Este Campo Esta Vacio")]
        [DisplayName("Nombre Alumno: ")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Este Campo Esta Vacio")]
        [DisplayName("Apellidos del Alumno: ")]
        public string apellido { get; set; }
        [Required(ErrorMessage = "Este Campo Esta Vacio")]
        [DisplayName("Fecha de Nacimiento: ")]
        [DataType(DataType.Date)]
        public string fecha_n { get; set; }
        [Required(ErrorMessage = "Seleccione un Género")]
        [DisplayName("Genero: ")]
        public String genero { get; set; }
        public int idUsuario { get; set; }

    }
}