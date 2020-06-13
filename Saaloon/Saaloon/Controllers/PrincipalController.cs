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
    [Access]
    public class PrincipalController : Controller
    {
        SessionData Sess = new SessionData();
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
            int idUsuario = int.Parse(Sess.getSession("idUsuario"));
            PerfilVM Model = new PerfilVM();
            Model.idUsuario = idUsuario;
            Usuario User = new Usuario();
            Alumno Alum = new Alumno();

            try
            {
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
            }catch(Exception e) { }

            return View(Model);
        }

        [HttpPost]
        public ActionResult Perfil(FormCollection e, PerfilVM model)
        {
            int idUser = int.Parse(Session["idUsuario"].ToString());

            using (var dbContext = new DBPortalEduDataContext())
            {
                Alumno Alum = (from db in dbContext.Alumno where idUser == db.idUsuario select db).Single();
                Alum.nombre = String.IsNullOrEmpty(model.nombre) ? Alum.nombre : model.nombre;
                Alum.apellido = String.IsNullOrEmpty(model.apellido) ? Alum.apellido : model.apellido;
                Alum.fecha_n = String.IsNullOrEmpty(model.fecha_n) ? Alum.fecha_n : Convert.ToDateTime(model.fecha_n);
                Alum.genero = (String.IsNullOrEmpty(model.genero) ? Alum.genero : model.genero == "Masculino" ? 'M' : 'F');
                dbContext.SP_ModificaAlumno(Alum.IdAlumno, Alum.nombre, Alum.apellido, Alum.fecha_n, Alum.genero);
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

        [HttpGet]
        public ActionResult ContenidoCursoTema(int idCurso)
        {
            CursoContenido objCurso = new CursoContenido();

            try
            {
                using (var dbContext = new DBPortalEduDataContext())
                {
                    Cursos curso = (from db in dbContext.Cursos where db.IdCurso == idCurso select db).Single();
                    List<Temario> temariodelcurso = (from db in dbContext.Temario where db.IdCurso == curso.IdCurso select db).ToList();
                    Docentes docente = (from db in dbContext.Docentes where db.IdDocente == curso.idDocente select db).Single();
                    int CursoComprado = (from db in dbContext.compras where db.idCursoComprado == idCurso && db.IdUsuario == Convert.ToInt32(Sess.getSession("idUsuario")) select db).Count();
                    int CursoListaDeseo = (from db in dbContext.Carrito where db.Id_UsuarioC == Convert.ToInt32(Sess.getSession("idUsuario")) && db.Id_CursoC == curso.IdCurso select db).Count();
                    //ViewBag.LoCompro = CursoComprado > 0 ? true : false;

                    objCurso.Id_CursoC = CursoComprado > 0 ? 2 : CursoListaDeseo > 0 ? 1 : 0;
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
            }catch (Exception e) { }

            return View(objCurso);
        }

        [HttpGet]
        public ActionResult ClaseTemaCurso(int idTema)
        {
            ClaseTema objClase = new ClaseTema();

            try
            {
                using (var dbContext = new DBPortalEduDataContext())
                {
                    Temario objtemario = (from db in dbContext.Temario where db.IdTema == idTema select db).Single();
                    List<Temario> clasetema = (from db in dbContext.Temario where db.IdCurso == objtemario.IdCurso select db).ToList();
                    Cursos cursocont = (from db in dbContext.Cursos where db.IdCurso == objtemario.IdCurso select db).Single();
                    Docentes docente = (from db in dbContext.Docentes where db.IdDocente == cursocont.idDocente select db).Single();

                    objClase.idTema = objtemario.IdTema;
                    objClase.IdCurso = Convert.ToInt32(objtemario.IdCurso);
                    objClase.Tema = objtemario.Tema;
                    objClase.DescripcionTema = objtemario.Descripcion;
                    objClase.FotoTema = objtemario.FotoTema;

                    objClase.NombreCurso = cursocont.Nombre;

                    objClase.idDocente = docente.IdDocente;
                    objClase.NombreDocente = docente.nombre;
                    objClase.ApellidoDocente = docente.apellido;

                    objClase.TemarioClase = clasetema;
                }
            }catch (Exception e) { }
            return View(objClase);
        }

        [HttpPost]
        public JsonResult AgregarListaDeseos(int idCurso)
        {
            try
            {
                using (var dbContext = new DBPortalEduDataContext())
                {
                    Cursos Cursito = (from db in dbContext.Cursos where db.IdCurso == idCurso select db).Single();
                    Carrito AddWish = new Carrito();
                    AddWish.Nombre = Cursito.Nombre;
                    AddWish.descripcion = Cursito.Descripcion;
                    AddWish.valorcompra = Cursito.Costo;
                    AddWish.Id_CursoC = Cursito.IdCurso;
                    AddWish.Id_UsuarioC = Convert.ToInt32(Sess.getSession("idUsuario"));
                    dbContext.Carrito.InsertOnSubmit(AddWish);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception e) { }
            return Json(new { exito = true }, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult QuitarListaDeseo(int idCurso)
        {
            try
            {
                using (var dbContext = new DBPortalEduDataContext())
                {
                    Carrito DeleteWish = (from db in dbContext.Carrito
                                          where db.Id_UsuarioC == Convert.ToInt32(Sess.getSession("idUsuario"))
                                          && db.Id_CursoC == idCurso
                                          select db).Single();
                    dbContext.Carrito.DeleteOnSubmit(DeleteWish);
                    dbContext.SubmitChanges();
                }
            }
            catch (Exception e) { }
            return Json(new { exito = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListCarrito()
        {
            List<Carrito> objCart = new List<Carrito>();
            int x = 0;

            try
            {
                using (var dbContext = new DBPortalEduDataContext())
                {
                    objCart = (from db in dbContext.Carrito where db.Id_UsuarioC == Convert.ToInt32(Sess.getSession("idUsuario")) select db).ToList();
                    x = objCart.Count();
                }

            }
            catch (Exception e)
            {

            }

            if (x != 0)
            {
                return View(objCart);
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult _PartialViewComprar(int idCurso)
        {
            DataCardVM MyCard = new DataCardVM();
            try
            {
                using (var dbContext = new DBPortalEduDataContext())
                {
                    Cursos Curs = (from db in dbContext.Cursos where db.IdCurso == idCurso select db).Single();
                    MyCard.idCurso = Curs.IdCurso;
                }
            }
            catch { }
            return PartialView(MyCard);
        }

        [HttpPost]
        public ActionResult Comprar(DataCardVM MyModel)
        {
            try
            {
                using (var dbContext = new DBPortalEduDataContext())
                {
                    Tarjeta Card = new Tarjeta();
                    Card.tipotc = MyModel.Tipotc;
                    Card.nombretc = MyModel.Nombretc;
                    Card.bancotc = MyModel.Bancotc;
                    Card.numerotc = MyModel.Numerotc;
                    Card.ccv = Convert.ToInt32(MyModel.CCV);
                    Card.mestc = Convert.ToInt32(MyModel.Mestc);
                    Card.aniotc = Convert.ToInt32(MyModel.Añotc);
                    Card.IdUsuariot = Convert.ToInt32(Sess.getSession("idUsuario"));
                    dbContext.Tarjeta.InsertOnSubmit(Card);
                    dbContext.SubmitChanges();

                    var List = (from db in dbContext.Tarjeta where db.IdUsuariot == Card.IdUsuariot select db).ToList();
                    var LastFinded = List.LastOrDefault();
                    var Curso = (from db in dbContext.Cursos where db.IdCurso == MyModel.idCurso select db).Single();

                    compras NuevaCompra = new compras();
                    NuevaCompra.fecha = DateTime.Today;
                    NuevaCompra.valorcompra = Curso.Costo;
                    NuevaCompra.IdUsuario = Card.IdUsuariot;
                    NuevaCompra.idtarjetac = LastFinded.idtarjeta;
                    NuevaCompra.idCursoComprado = Curso.IdCurso;
                    dbContext.compras.InsertOnSubmit(NuevaCompra);
                    dbContext.SubmitChanges();

                    Carrito EliminaListaDeseo = (from db in dbContext.Carrito where db.Id_CursoC == NuevaCompra.idCursoComprado select db).Single();
                    dbContext.Carrito.DeleteOnSubmit(EliminaListaDeseo);
                    dbContext.SubmitChanges();
                }
            }
            catch { }
            return RedirectToAction("ListCarrito", "Principal");
        }

        public ActionResult MisCompras()
        {
            List<compras> ListadoComprado = new List<compras>();
            int x = 0;
            try
            {
                using (var dbContext = new DBPortalEduDataContext())
                {
                    ListadoComprado = (from db in dbContext.compras where db.IdUsuario == Convert.ToInt32(Sess.getSession("idUsuario")) select db).ToList();
                    x = ListadoComprado.Count();
                }
            }
            catch { }
            if(x != 0)
            {
                return View(ListadoComprado);
            }
            return View();
        }

    }
}