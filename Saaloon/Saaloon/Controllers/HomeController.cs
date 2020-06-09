using Saaloon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Saaloon.Context;

namespace Saaloon.Controllers
{
    public class HomeController : Controller
    {
        SessionData session = new SessionData();
        // GET: Home
        public ActionResult Index()
        {
            //session.destroySession();
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login (Login datos)
        {

            if (ModelState.IsValid)
            {
                if(datos.Validacion())
                {
                    session.setSession("Usuario", datos.Usuario);
                    session.setSession("idUsuario", datos.IdUsuario.ToString());
                    session.setSession("TipoUsuario", datos.tipo);
                    if(datos.tipo == "3")
                    {
                        session.setSession("Tipo3", datos.tipo);
                    }
                    else
                    {
                        session.setSession("Tipo2", datos.tipo);
                    }
                }
            }

            return RedirectToAction("LogIn", "Users");
        }

        public ActionResult Registrarse()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Registrarse(Registrarse NewUser)
        {
            using (var dbContext = new DBPortalEduDataContext())
            {
                Usuario user = new Usuario();
                Alumno Alum = new Alumno();

                user.Usuario1 = NewUser.Usuario;
                user.correo = NewUser.correo;
                user.contraseña = NewUser.contraseña;
                user.tipo = 3;
                user.Activo = 1;

                dbContext.Usuario.InsertOnSubmit(user);
                dbContext.SubmitChanges();

                var ListUsers = (from db in dbContext.Usuario select db).ToList();
                user = ListUsers.LastOrDefault();

                Alum.nombre = NewUser.nombre;
                Alum.apellido = NewUser.apellido;
                //Alum.genero = NewUser.genero;
                Alum.fecha_n = Convert.ToDateTime(NewUser.fecha_n);
                Alum.idUsuario = user.IdUsuario;
            }
                return RedirectToAction("Login", "Home");
        }

        //************************CLIENT'S SIDE VALIDATIONS****************************

        public JsonResult UserRequestValidation(string Usuario)
        {
            return Json(UsuarioRegistrado(Usuario));
        }



        public bool UsuarioRegistrado(string User)
        {
            bool ifExist;

            using (var dbContext = new DBPortalEduDataContext())
            {
                var UsuRegis = (from db in dbContext.Usuario
                                where db.Usuario1.ToUpper() == User.ToUpper()
                                select new { User }).FirstOrDefault();

                ifExist = UsuRegis != null ? false : true;
            }

            return ifExist;
        }



        [HttpPost]
        public JsonResult EmailRequestValidation(string correo)
        {
            return Json(CorreoRegistrado(correo));
        }
        public bool CorreoRegistrado(string Email)
        {

            bool IfExist;

            using (var dbContext = new DBPortalEduDataContext())
            {
                var EmailExist = (from db in dbContext.Usuario
                                  where db.correo.ToUpper() == Email.ToUpper()
                                  select new { Email }).FirstOrDefault();

                IfExist = EmailExist != null ? false : true;
            }

            return IfExist;
        }

    }
}