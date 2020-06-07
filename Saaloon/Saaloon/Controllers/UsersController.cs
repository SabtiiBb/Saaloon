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

        public ActionResult Users()
        {
            ViewBag.User = session.getSession("Usuario");
            if (!String.IsNullOrEmpty(ViewBag.User))
            {
                return RedirectToAction("Principal", "Principal");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Close()
        {
            session.destroySession();
            return RedirectToAction("Index", "Home");
        }
    }
}