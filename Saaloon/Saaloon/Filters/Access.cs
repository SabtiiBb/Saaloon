using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saaloon.Filters
{
    public class Access : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Si Variable de Session is Null, return Login Or Type isn't a Student

            var usuario = HttpContext.Current.Session["Usuario"];
            string tipo = HttpContext.Current.Session["TipoUsuario"].ToString();
            if(usuario == null || tipo != "3")
            {
                filterContext.Result = new RedirectResult("~/Users/LogIn");
            }

            base.OnActionExecuted(filterContext);
        }
    }
}