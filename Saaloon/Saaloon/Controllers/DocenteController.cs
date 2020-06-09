using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Saaloon.Context;
using Saaloon.Models;
using Saaloon.Filters;

namespace Saaloon.Controllers
{
    [TAccess]
    public class DocenteController : Controller
    {
        SessionData Sess = new SessionData();
        // GET: Docente
        [TAccess]
        public ActionResult Index()
        {
            List<Cursos> MisCursos;

            using (var dbContext = new DBPortalEduDataContext())
            {
                Docentes doc = (from db in dbContext.Docentes where db.idUsuario == Convert.ToInt32(Sess.getSession("idUsuario")) select db).Single();
                MisCursos = (from db in dbContext.Cursos where db.idDocente == doc.IdDocente select db).ToList();
            }
                return View(MisCursos);
        }

        [TAccess]
        [HttpGet]
        public ActionResult PerfilDocente()
        {
            int idUsuario = int.Parse(Sess.getSession("idUsuario"));
            PerfilDocente Model = new PerfilDocente();
            Model.idUsuario = idUsuario;
            Docentes Doc = new Docentes();
            Usuario User = new Usuario();

            using (var dbContext = new DBPortalEduDataContext())
            {
                User = (from db in dbContext.Usuario where db.IdUsuario == Model.idUsuario select db).Single();
                Doc = (from db in dbContext.Docentes where db.idUsuario == Model.idUsuario select db).Single();

                Model.Usuario1 = User.Usuario1;
                Model.correo = User.correo;
                Model.nombre = Doc.nombre;
                Model.apellido = Doc.apellido;
                Model.fecha_n = Doc.fecha_n.ToString();
                Model.genero = (Doc.genero).ToString() == "M" ? "Masculino" : "Femenino";
            }

            return View(Model);
        }

        [HttpPost]
        public ActionResult PerfilDocente(FormCollection e, PerfilDocente model)
        {
            int idUser = int.Parse(Session["IdUsuario"].ToString());

            using (var dbContext = new DBPortalEduDataContext())
            {
                Docentes Doce = (from db in dbContext.Docentes where idUser == db.idUsuario select db).Single();
                Doce.nombre = String.IsNullOrEmpty(model.nombre) ? Doce.nombre : model.nombre;
                Doce.apellido = String.IsNullOrEmpty(model.apellido) ? Doce.apellido : model.apellido;
                Doce.fecha_n = String.IsNullOrEmpty(model.fecha_n) ? Doce.fecha_n : Convert.ToDateTime(model.fecha_n);
                Doce.genero = (String.IsNullOrEmpty(model.genero) ? Doce.genero : model.genero == "Masculino" ? 'M' : 'F');
                dbContext.SP_ModificaDocente(Doce.IdDocente, Doce.nombre, Doce.apellido, Doce.fecha_n, Doce.genero);

            }
            return RedirectToAction("PerfilDocente", "Docente");
        }

        [TAccess]
        [HttpGet]
        public ActionResult CrearCurso()
        {
            List<Docentes> docentes;

            List<SelectListItem> lst = new List<SelectListItem>();

            using (var dbContext = new DBPortalEduDataContext())
            {
                docentes = (from db in dbContext.Docentes select db).ToList();
                foreach (var item in docentes)
                {
                    lst.Add(new SelectListItem() { Text = item.nombre, Value = item.IdDocente.ToString() });
                }
            }
            ViewBag.docente = lst;

            return View();
        }

        [HttpPost]
        public ActionResult CrearCurso(FormCollection c, CrearCursoDoc MyModel)
        {
            using (var dbContext = new DBPortalEduDataContext())
            {
                Cursos Curso = new Cursos();

                Curso.Nombre = MyModel.Nombre;
                Curso.Descripcion = MyModel.Descripcion;
                Curso.Recursos = MyModel.Recursos;
                Curso.Costo = MyModel.Costo;
                Curso.idDocente = Convert.ToInt32(MyModel.idDocente);
                Curso.Foto = MyModel.Foto;
                Curso.Videointro = MyModel.VideoIntro;
                dbContext.Cursos.InsertOnSubmit(Curso);
                dbContext.SubmitChanges();

                var List = (from dbD in dbContext.Cursos select dbD).ToList();
                Curso = List.LastOrDefault();
                MyModel.idCurso = Curso.IdCurso;
            }

            var modelito = MyModel;
            return RedirectToAction("CrearTemario", "Docente", modelito);
        }

        [TAccess]
        [HttpGet]
        public ActionResult CrearTemario(CrearCursoDoc Model)
        {
            return View(Model);
        }

        [HttpPost]
        public ActionResult CrearTemario(FormCollection e, CrearCursoDoc MyModel)
        {
            using (var dbContext = new DBPortalEduDataContext())
            {
                Temario TempTemp = new Temario();
                TempTemp.IdCurso = MyModel.idCurso;
                TempTemp.Tema = MyModel.NombreTema;
                TempTemp.Descripcion = MyModel.DescripcionTema;
                TempTemp.FotoTema = MyModel.VideoTema;

                dbContext.Temario.InsertOnSubmit(TempTemp);
                dbContext.SubmitChanges();

                MyModel.NombreTema = "";
                MyModel.DescripcionTema = "";
                MyModel.VideoTema = "";
            }
            return RedirectToAction("CrearTemario", "Docente", MyModel);
        }
    }
}