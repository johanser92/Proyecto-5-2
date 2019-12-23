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
    public class EquipoController : Controller
    {
        private Softball_TeamsEntities db = new Softball_TeamsEntities();

        // GET: Equipo
        public ActionResult Index()
        {
            return View(db.tbl_Equipo.ToList());
        }

        // GET: Equipo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Equipo tbl_Equipo = db.tbl_Equipo.Find(id);
            if (tbl_Equipo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Equipo);
        }

        // GET: Equipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipoID,Nombre,Ciudad,JugadorID")] tbl_Equipo tbl_Equipo)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Equipo.Add(tbl_Equipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Equipo);
        }

        // GET: Equipo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Equipo tbl_Equipo = db.tbl_Equipo.Find(id);
            if (tbl_Equipo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Equipo);
        }

        // POST: Equipo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipoID,Nombre,Ciudad,JugadorID")] tbl_Equipo tbl_Equipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Equipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Equipo);
        }

        // GET: Equipo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Equipo tbl_Equipo = db.tbl_Equipo.Find(id);
            if (tbl_Equipo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Equipo);
        }

        // POST: Equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Equipo tbl_Equipo = db.tbl_Equipo.Find(id);
            db.tbl_Equipo.Remove(tbl_Equipo);
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
