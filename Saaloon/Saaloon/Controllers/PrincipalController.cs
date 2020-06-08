using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Saaloon.Context;
using Saaloon.Models;

namespace Saaloon.Controllers
{
    [Authorize]
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult Principal()
        {
            List<Context.Cursos> Listado;

            using (var dbContext = new DBPortalEduDataContext())
            {
                Listado = (from db in dbContext.Cursos select db).ToList();
            }

                return View(Listado);
        }

        [HttpGet]
        public ActionResult Perfil()
        {
            int idUsuario = int.Parse(Session["IdUsuario"].ToString());
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
                Model.fecha_n = Alum.fecha_n.ToString();
                Model.genero = (Alum.genero).ToString() == "M" ? "Masculino" : "Femenino";
            }

            return View(Model);
        }

        [HttpPost]
        public ActionResult Perfil(FormCollection e, PerfilVM model)
        {
            int idUser = int.Parse(Session["IdUsuario"].ToString());

            using (var dbContext = new DBPortalEduDataContext())
            {
                Alumno Alum = (from db in dbContext.Alumno where idUser == db.idUsuario select db).Single();
                Alum.nombre = String.IsNullOrEmpty(model.nombre) ? Alum.nombre : model.nombre;
                Alum.apellido = String.IsNullOrEmpty(model.apellido) ? Alum.apellido : model.apellido;
                Alum.fecha_n = String.IsNullOrEmpty(model.fecha_n) ? Alum.fecha_n : Convert.ToDateTime(model.fecha_n);
                Alum.genero = (String.IsNullOrEmpty(model.genero) ? Alum.genero : model.genero == "Masculino" ? 'M' : 'F');
                dbContext.SP_ModificaAlumno(idUser, Alum.nombre, Alum.apellido, Alum.fecha_n, Alum.genero);
            }
                return RedirectToAction("Perfil", "Principal");
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

        public ActionResult ContenidoCursoTema(int idCurso)
        {
            CursoContenido objCurso = new CursoContenido();

            using (var dbContext = new DBPortalEduDataContext())
            {
                Cursos curso = (from db in dbContext.Cursos where db.IdCurso == idCurso select db).Single();
                List<Temario> temariodelcurso = (from db in dbContext.Temario where db.IdCurso == curso.IdCurso select db).ToList();
                Docentes docente = (from db in dbContext.Docentes where db.IdDocente == curso.idDocente select db).Single();

                objCurso.IdCurso = curso.IdCurso;
                objCurso.NombreCurso = curso.Nombre;
                objCurso.Descripcion = curso.Descripcion;
                objCurso.RecursosCurso = curso.Recursos;
                objCurso.CostoCurso = Convert.ToDecimal(curso.Costo);
                objCurso.Foto = curso.Foto;
                objCurso.Videointro = curso.Videointro;

                objCurso.TemarioM = temariodelcurso;

                objCurso.IdDocente = docente.IdDocente;
                objCurso.Nombre = docente.nombre;
                objCurso.Apellido = docente.apellido;
            }

            return View(objCurso);
        }

        
        public ActionResult ClaseTemaCurso(int idTema)
        {
            ClaseTema objClase = new ClaseTema();

            using (var dbContext = new DBPortalEduDataContext())
            {
                Temario objtemario = (from db in dbContext.Temario where db.IdTema == idTema select db).Single();
                List<Temario> clasetema = (from db in dbContext.Temario where db.IdCurso == objtemario.IdCurso select db).ToList();
                Cursos cursocont = (from db in dbContext.Cursos where db.IdCurso == objtemario.IdCurso select db).Single();
                Docentes docente = (from db in dbContext.Docentes where db.IdDocente == cursocont.idDocente select db).Single();

                objClase.idTema = objtemario.IdTema;
                objClase.IdCurso =Convert.ToInt32(objtemario.IdCurso);
                objClase.Tema = objtemario.Tema;
                objClase.DescripcionTema = objtemario.Descripcion;
                objClase.FotoTema = objtemario.FotoTema;

                objClase.NombreCurso = cursocont.Nombre;

                objClase.idDocente = docente.IdDocente;
                objClase.NombreDocente = docente.nombre;
                objClase.ApellidoDocente = docente.apellido;

                objClase.TemarioClase = clasetema;
            }
            return View(objClase);
        }

        [HttpGet]
        public ActionResult PerfilDocente()
        {
            int idUsuario = int.Parse(Session["IdUsuario"].ToString());
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
                dbContext.SP_ModificaDocente(idUser, Doce.nombre, Doce.apellido, Doce.fecha_n, Doce.genero);

            }
            return RedirectToAction("PerfilDocente", "Principal");
        }

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
            return RedirectToAction("CrearTemario", "Principal", modelito);
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
            return RedirectToAction("CrearTemario", "Principal", MyModel);
        }

    }
}