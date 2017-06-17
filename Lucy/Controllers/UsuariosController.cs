﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelCL;
using Lucy.Models;

namespace Lucy.Controllers
{
    public class UsuariosController : Controller
    {
        private AgustinaEntities db = new AgustinaEntities();

        public ActionResult Registro()
        {
            //if (Request.RequestType == "GET")
            //{
            RegistroViewModel Registro = new RegistroViewModel();
            //List<ModelCL.Sexo> lSexo = new List<ModelCL.Sexo>();
            //lSexo = db.Sexoes.ToList();
            //ViewBag.listaSexos = lSexo;
            List<ModelCL.Sexo> lSexo = db.Sexo.ToList();
            ViewBag.listaSexos = new SelectList(lSexo, "SexoId", "SexoNombre");
            return View();
            //}
            //else
            //{

            //    return Content("Guardado");
            //}
        }

        public ActionResult RegistroPost(RegistroViewModel Registro)
        {
            try
            {
                ModelCL.Usuario Usuario = new ModelCL.Usuario();
                Usuario.UsuarioNombre = Registro.UsuarioNombre;
                Usuario.UsuarioEmail = Registro.UsuarioEmail;
                Usuario.UsuarioPass = Registro.UsuarioPass;
                Usuario.UsuarioApp = "Web";

                db.Usuario.Add(Usuario);

                ModelCL.Persona Persona = new ModelCL.Persona();
                Persona.PersonaNombre = Registro.PersonaNombre;
                Persona.PersonaApellido = Registro.PersonaApellido;
                Persona.PersonaFchNac = Registro.PersonaFchNac;
                Persona.SexoId = Registro.SexoId;

                db.Persona.Add(Persona);

                Usuario.Persona.Add(Persona);
                Persona.Usuario.Add(Usuario);

                db.Usuario.Add(Usuario);
                db.Persona.Add(Persona);

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Content("Guardado");
        }

            // GET: Usuarios
            public ActionResult Index()
        {
            return View(db.Usuario.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioId,UsuarioNombre,UsuarioEmail,UsuarioPass,UsuarioImg,UsuarioFchIng,UsuarioApp")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioId,UsuarioNombre,UsuarioEmail,UsuarioPass,UsuarioImg,UsuarioFchIng,UsuarioApp")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
