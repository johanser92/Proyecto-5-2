using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto._5_2.Models.Models;

namespace Proyecto._5_2.Web.Controllers
{
    public class JugadorController : Controller
    {
        private Softball_TeamsEntities db = new Softball_TeamsEntities();

        // GET: Jugador
        public ActionResult Index()
        {
            var tbl_Jugador = db.tbl_Jugador.Include(t => t.tbl_Equipo);
            return View(tbl_Jugador.ToList());
        }

        // GET: Jugador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Jugador tbl_Jugador = db.tbl_Jugador.Find(id);
            if (tbl_Jugador == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Jugador);
        }

        // GET: Jugador/Create
        public ActionResult Create()
        {
            ViewBag.EquipoID = new SelectList(db.tbl_Equipo, "EquipoID", "Nombre");
            return View();
        }

        // POST: Jugador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JugadorID,Nombres,Apellidos,Edad,Posicion,EquipoID")] tbl_Jugador tbl_Jugador)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Jugador.Add(tbl_Jugador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipoID = new SelectList(db.tbl_Equipo, "EquipoID", "Nombre", tbl_Jugador.EquipoID);
            return View(tbl_Jugador);
        }

        // GET: Jugador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Jugador tbl_Jugador = db.tbl_Jugador.Find(id);
            if (tbl_Jugador == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipoID = new SelectList(db.tbl_Equipo, "EquipoID", "Nombre", tbl_Jugador.EquipoID);
            return View(tbl_Jugador);
        }

        // POST: Jugador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JugadorID,Nombres,Apellidos,Edad,Posicion,EquipoID")] tbl_Jugador tbl_Jugador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Jugador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipoID = new SelectList(db.tbl_Equipo, "EquipoID", "Nombre", tbl_Jugador.EquipoID);
            return View(tbl_Jugador);
        }

        // GET: Jugador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Jugador tbl_Jugador = db.tbl_Jugador.Find(id);
            if (tbl_Jugador == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Jugador);
        }

        // POST: Jugador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Jugador tbl_Jugador = db.tbl_Jugador.Find(id);
            db.tbl_Jugador.Remove(tbl_Jugador);
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
