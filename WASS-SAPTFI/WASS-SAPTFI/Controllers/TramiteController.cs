using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelos;
using Datos;

namespace WASS_SAPTFI.Controllers
{
    public class TramiteController : Controller
    {
        private WASSDbContext db = new WASSDbContext();

        //
        // GET: /Tramite/

        public ActionResult Index()
        {
            return View(db.Tramites.ToList());
        }

        //
        // GET: /Tramite/Details/5

        public ActionResult Details(int id = 0)
        {
            Tramite tramite = db.Tramites.Find(id);
            if (tramite == null)
            {
                return HttpNotFound();
            }
            return View(tramite);
        }

        //
        // GET: /Tramite/Create

        public ActionResult Create()
        {
            ViewBag.ListaTipos_Tramite = db.Tipos_Tramites.ToList();
            return View();
        }

        //
        // POST: /Tramite/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tramite tramite)
        {
            if (ModelState.IsValid)
            {
                db.Tramites.Add(tramite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tramite);
        }

        //
        // GET: /Tramite/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tramite tramite = db.Tramites.Find(id);
            if (tramite == null)
            {
                return HttpNotFound();
            }
            return View(tramite);
        }

        //
        // POST: /Tramite/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tramite tramite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tramite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tramite);
        }

        //
        // GET: /Tramite/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tramite tramite = db.Tramites.Find(id);
            if (tramite == null)
            {
                return HttpNotFound();
            }
            return View(tramite);
        }

        //
        // POST: /Tramite/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tramite tramite = db.Tramites.Find(id);
            db.Tramites.Remove(tramite);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}