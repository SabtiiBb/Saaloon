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
        public ActionResult Index()
        {
            List<Cursos> MisCursos = new List<Cursos>();

            try
            {
                using (var dbContext = new DBPortalEduDataContext())
                {
                    Docentes doc = (from db in dbContext.Docentes where db.idUsuario == Convert.ToInt32(Sess.getSession("idUsuario")) select db).Single();
                    MisCursos = (from db in dbContext.Cursos where db.idDocente == doc.IdDocente select db).ToList();
                }
            }catch (Exception e) { }

                return View(MisCursos);
        }

        [HttpGet]
        public ActionResult PerfilDocente()
        {
            int idUsuario = int.Parse(Sess.getSession("idUsuario"));
            PerfilDocente Model = new PerfilDocente();
            Model.idUsuario = idUsuario;
            Docentes Doc = new Docentes();
            Usuario User = new Usuario();

            try
            {
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
            }catch(Exception e)
            {
                
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

        [HttpGet]
        public ActionResult CrearCurso()
        {
            List<Docentes> docentes;

            List<SelectListItem> lst = new List<SelectListItem>();

            try
            {
                using (var dbContext = new DBPortalEduDataContext())
                {
                    docentes = (from db in dbContext.Docentes select db).ToList();
                    foreach (var item in docentes)
                    {
                        lst.Add(new SelectListItem() { Text = item.nombre, Value = item.IdDocente.ToString() });
                    }
                }
            }catch(Exception e) { }
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


        [HttpGet]
        public ActionResult ListaTemarios (int idCurso)
        {
            ListaCurso objCurso = new ListaCurso();

            using (var dbContext = new DBPortalEduDataContext())
            {
                Cursos curso = (from db in dbContext.Cursos where db.IdCurso == idCurso select db).Single();
                List<Temario> temariodelcurso = (from db in dbContext.Temario where db.IdCurso == curso.IdCurso select db).ToList();
                Docentes docente = (from db in dbContext.Docentes where db.IdDocente == curso.idDocente select db).Single();

                objCurso.IdCurso = curso.IdCurso;
                objCurso.NombreCurso = curso.Nombre;
                objCurso.TemarioM = temariodelcurso;
                objCurso.IdDocente = docente.IdDocente;

            }

            return View(objCurso);
        }

        [HttpGet]
        public ActionResult EditarCurso(int idCurso)
        {
            EditarMiCursoVM MyModel= new EditarMiCursoVM();

            try
            {
                using (var dbContext = new DBPortalEduDataContext())
                {
                    Cursos Curs = (from dbD in dbContext.Cursos where dbD.IdCurso == idCurso select dbD).Single();
                    List<Temario> temario = (from dbD in dbContext.Temario where dbD.IdCurso == idCurso select dbD).ToList();
                    Docentes doc = (from dbD in dbContext.Docentes where dbD.IdDocente == Curs.idDocente select dbD).Single();

                    MyModel.IdCurso = idCurso;
                    MyModel.Nombre = Curs.Nombre;
                    MyModel.Descripcion = Curs.Descripcion;
                    MyModel.Costo = Convert.ToDecimal(Curs.Costo);
                    MyModel.idDocente = Convert.ToInt32(Curs.idDocente);
                    MyModel.Recursos = Curs.Recursos;
                    MyModel.NombreDocente = doc.apellido + ", " + doc.nombre;
                    MyModel.Foto = Curs.Foto;
                    MyModel.VideoIntro = Curs.Videointro;
                    MyModel.temario = temario;
                }
            }
            catch (Exception e) { }
            return View(MyModel);
        }

        [HttpPost]
        public ActionResult EditarCurso(EditarMiCursoVM MyModel)
        {
            try
            {
                using (var dbContext = new DBPortalEduDataContext())
                {
                    Cursos Curs = (from dbD in dbContext.Cursos where dbD.IdCurso == MyModel.IdCurso select dbD).Single();
                    Curs.Nombre = MyModel.Nombre;
                    Curs.Descripcion = MyModel.Descripcion;
                    Curs.Costo = Convert.ToDecimal(MyModel.Costo);
                    Curs.idDocente = Convert.ToInt32(MyModel.idDocente);
                    Curs.Recursos = MyModel.Recursos;
                    Curs.Foto = MyModel.Foto;
                }
            }
            catch (Exception e) { }
            return RedirectToAction("CrearTemario", "Docente", MyModel);
        }
    }
}