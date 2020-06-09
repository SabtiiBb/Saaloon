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
            var tipo = HttpContext.Current.Session["TipoUsuario"];
            var tipo2 = HttpContext.Current.Session["Tipo2"];
            if (usuario == null || tipo != tipo2)
            {
                filterContext.Result = new RedirectResult("~/Home/Login");
            }
            base.OnActionExecuted(filterContext);
        }
    }
}