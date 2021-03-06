﻿using System;
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

       public Modelos.Persona dbPersonas
       {
           get
           {
               throw new System.NotImplementedException();
           }
           set
           {
           }
       }



        //[HttpGet]
        //Autocompletar para la busqueda
        public ActionResult Autocomplete(string term)
        {
            var model = db.Personas
                .Where(p => p.NombreYapellido.StartsWith(term))
                .Take(10)
                .Select(p => new
                {
                    label = p.NombreYapellido
                });

            return Json(model, JsonRequestBehavior.AllowGet);
        }




        //
        // GET: /dbPersonas/

        public ActionResult Index(string searchTerm)
        {
           
            if (Request.IsAjaxRequest())
            {
                 return PartialView("_ListaPersonas", ObtenerListaPersonas(searchTerm));
            }
            

            return View(ObtenerListaPersonas(searchTerm));

        }

        public List<Persona> ObtenerListaPersonas(string filtro)
        {
            //Armo la lista
            List<Persona> listaPersona = new List<Persona>();
            listaPersona.Clear();

        //Si ingrese parametro de busqueda
           if(filtro != null)
           { 
               //recorro la lista
                foreach(Persona p in db.Personas.ToList())
                {
                   //Si el parametro coincide con el nombre y apellido
                    if (p.NombreYapellido.ToLower().StartsWith(filtro.ToLower()))
                    {
                        //agrego la persona
                        listaPersona.Add(p);
                    }
                }
                
           }//NO INGRESE PARAMETRO DE BUSQUEDA
           else
           {
               listaPersona = db.Personas.ToList();
           }


           return listaPersona;
        }



        //
        // GET: /dbPersonas/Details/5

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
        // GET: /dbPersonas/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /dbPersonas/Create

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
        // GET: /dbPersonas/Edit/5

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
        // POST: /dbPersonas/Edit/5

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
        // GET: /dbPersonas/Delete/5

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
        // POST: /dbPersonas/Delete/5

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
        //GET: /dbPersonas/SeleccionarPersona
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