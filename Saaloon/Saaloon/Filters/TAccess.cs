using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saaloon.Filters
{
    public class TAccess : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Si Variable de Session is Null, return Login or Type isn't a Teacher

            var usuario = HttpContext.Current.Session["Usuario"];
            string tipo = HttpContext.Current.Session["TipoUsuario"].ToString();
            if (usuario == null || tipo != "2")
            {
                filterContext.Result = new RedirectResult("~/Users/LogIn");
            }
            base.OnActionExecuted(filterContext);
        }
    }
}