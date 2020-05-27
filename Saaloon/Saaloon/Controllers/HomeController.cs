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
        // GET: Home
        public ActionResult Index()
        {
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
                    Session["Usuario"] = datos.Usuario;
                    return View("~/Views/Principal/Principal.cshtml");
                }
                else
                {
                    return View("Login");
                }
                return View();
            }
            else
            {
                return View("Login");
            }
        }

    }
}