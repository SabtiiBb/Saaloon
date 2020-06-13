using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Saaloon.Context;
using System.Web.Mvc;

namespace Saaloon.Models
{
    public class Registrarse
    {
        //Tabla Usuario
        [Required]
        [Remote("UserRequestValidation", "Home", HttpMethod = "POST", ErrorMessage = "El Nombre de usuario ya se encuentra en uso!")]
        public String Usuario { get; set; }

        [Required]
        [Remote("EmailRequestValidation", "Home", HttpMethod = "POST", ErrorMessage = "Este Correo ya se encuentra en uso!")]
        public String correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public String contraseña { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("contraseña", ErrorMessage = "La Contraseña no coincide!")]
        public String ConfirmarContraseña { get; set; }

        //public Alumno Alum = new Alumno();

        //Tabla Alumno
        public String nombre { get; set; }
        public String apellido { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha_n { get; set; }
        public  String genero { get; set; }


        //DBPortalEduDataContext user = new DBPortalEduDataContext();

        //Usuario obj = new Usuario();

        //public bool singIn()
        //{
        //    var query = from db in user.Usuario
        //                where db.correo == correo ||
        //                db.Usuario1 == Usuario
        //                select db;
        //    if (query.Count() >0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        obj.Usuario1 = Usuario;
        //        obj.correo = correo;
        //        obj.contraseña = contraseña;
        //        user.Usuario.InsertOnSubmit(obj);
        //        user.SubmitChanges();

        //        //------------------------------------------------------------------------------

        //        IEnumerable<Usuario> ListadoUsuarios = (from db in user.Usuario select db);
        //        var LastUser = ListadoUsuarios.Last();

        //        Alumno Alum = new Alumno();

        //        Alum.idUsuario = Convert.ToInt32(LastUser.IdUsuario);
        //        Alum.nombre = nombre;
        //        Alum.apellido = apellido;
        //        Alum.fecha_n = fecha_n;
                

        //        //----------------------------------------------------------------------

        //        //user.Usuario.InsertOnSubmit(obj);
        //        user.Alumno.InsertOnSubmit(Alum);
        //        user.SubmitChanges();
        //        return true;
        //    }
        //}

    }
}