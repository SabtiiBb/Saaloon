using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Saaloon.Context;
using Saaloon.Models;

namespace Saaloon.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult Principal()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Perfil(int idUsuario)
        {
            PerfilVM Model = new PerfilVM();
            Model.idUsuario = idUsuario;
            Usuario User = new Usuario();
            Alumno Alum = new Alumno();

            using (var dbContext = new DBPortalEduDataContext())
            {
                User = (from db in dbContext.Usuario where db.IdUsuario == Model.idUsuario select db).Single();
                Alum = (from db in dbContext.Alumno where db.idUsuario == Model.idUsuario select db).Single();

                Model.Usuario1 = User.Usuario1;
                Model.correo = User.correo;
                Model.nombre = Alum.nombre;
                Model.apellido = Alum.apellido;
                Model.fecha_n = Convert.ToDateTime(Alum.fecha_n);
                Model.genero = Convert.ToChar(Alum.genero);

            }

            return View(Model);
        }

        [HttpGet]
        public ActionResult ListadoCursos()
        {
            List<Context.Cursos> ListaCursos;

            using (var dbContext = new DBPortalEduDataContext())
            {
                ListaCursos = (from db in dbContext.Cursos select db).ToList();
            }

                return View(ListaCursos);
        }
    }
}