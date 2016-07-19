using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelos;
using Datos;
using WASS_SAPTFI.ViewModels.Persona;

namespace WASS_SAPTFI.Controllers
{
    public class PersonaController : Controller
    {
        private WASSDbContext db = new WASSDbContext();

        //
        // GET: /Persona/

        public ActionResult Index()
        {

          // if (Request.IsAjaxRequest())
          //  {
          //      return PartialView("_ListaPersonas", db.Personas.ToList());
          //  }
            return View(db.Personas.ToList());
        }

        //
        // GET: /Persona/Details/5

        public ActionResult Details(int id = 0)
        {
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        //
        // GET: /Persona/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Persona/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(persona);
        }

        //
        // GET: /Persona/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        //
        // POST: /Persona/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        //
        // GET: /Persona/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        //
        // POST: /Persona/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Personas.Find(id);
            db.Personas.Remove(persona);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //
        //GET: /Persona/SeleccionarPersona
        public ActionResult SeleccionarPersona(int id)
        {
            //Busco una persona por ID
            Persona oPersona = db.Personas.Find(id);

            if (oPersona == null)
            {
                return HttpNotFound();
            }
            {//Si la encuentro, le asigno a PersonaViewModel las propiedades de esa persona
                var model = from p in db.Personas
                            select new PersonaVM
                            {
                                Id = p.Id,
                                NombreYapellido = p.NombreYapellido,
                                DNI = p.DNI,
                                Tipo_Persona = p.Tipo_Persona
                            };
                //y mando PersonaVM a la vista
                return View(model);
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}