﻿using System;
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
    }
}