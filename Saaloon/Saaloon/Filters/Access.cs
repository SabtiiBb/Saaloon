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
            var tipo = HttpContext.Current.Session["TipoUsuario"];
            var tipo3 = HttpContext.Current.Session["Tipo3"];
            if(usuario == null || tipo != tipo3)
            {
                filterContext.Result = new RedirectResult("~/Home/Login");
            }

            base.OnActionExecuted(filterContext);
        }
    }
}