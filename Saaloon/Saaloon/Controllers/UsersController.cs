using Saaloon.Models; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saaloon.Controllers
{
    public class UsersController : Controller
    {
        SessionData session = new SessionData();
        // GET: Users

        public ActionResult LogIn()
        {

            string UType = session.getSession("TipoUsuario");

            if(UType == "2")
            {
                return RedirectToAction("Index", "Docente");
            }else if(UType == "3")
            {
                return RedirectToAction("Principal", "Principal");
            }
            else
            {
                ViewBag.Message = "Error";
            }

            return View(ViewBag.Message);
        }

        public ActionResult Close()
        {
            session.destroySession();
            return RedirectToAction("Index", "Home");
        }
    }
}