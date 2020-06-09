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
                if (datos.Validacion())
                {
                    session.setSession("Usuario", datos.Usuario);
                    session.setSession("TipoUsuario", datos.tipo);
                    ViewBag.User1 = session.getSession("Usuario");
                    Session["IdUsuario"] = datos.IdUsuario;
                    return RedirectToAction("LogIn","Users");
                }
                else
                {
                    ViewBag.Message = "Error";
                    return View("LogIn", "Users");
                }
            }
            else
            {
                return View("Principal");
            }
        }


        //[AllowAnonymous]
        //public ActionResult Registrarse()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<ActionResult> Registrarse(Registrarse datos)
        //{C:\Users\Eduardo\Source\Repos\SabtiiBb\Saaloon\Saaloon\Saaloon\Controllers\UsersController.cs
        //    if (ModelState.IsValid)
        //    {
        //        if (datos.singIn() == false)
        //        {
        //            ViewBag.Message = "El usuario o el email ya estan registrados";
        //            return View("Registrarse", datos);
        //        }
        //        else
        //        {
        //            return RedirectToAction("Login");
        //        }

        //    }else
        //    {
        //        return View("Registrarse");
        //    }
        //}

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