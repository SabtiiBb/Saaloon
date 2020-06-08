using Saaloon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Saaloon.Controllers
{
    public class HomeController : Controller
    {
        SessionData session = new SessionData();
        // GET: Home
        public ActionResult Index()
        {
            session.destroySession();
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
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
                if (datos.Validacion() == true)
                {
                    session.setSession("Usuario", datos.Usuario);
                    ViewBag.User = session.getSession("Usuario");
                    //Session["Usuario"] = datos.Usuario;
                    Session["IdUsuario"] = datos.IdUsuario;
                    return RedirectToAction("Principal", "Principal");
                }
                else
                {
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }
        }
        [AllowAnonymous]
        public ActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Registrarse(Registrarse datos)
        {
            if (ModelState.IsValid)
            {
                if (datos.singIn() == false)
                {
                    ViewBag.Message = "El usuario o el email ya estan registrados";
                    return View("Registrarse", datos);
                }
                else
                {
                    return RedirectToAction("Login");
                }

            }else
            {
                return View("Registrarse");
            }
        }
    }
}