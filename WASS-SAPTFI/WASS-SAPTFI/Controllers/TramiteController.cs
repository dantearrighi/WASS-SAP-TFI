using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelos;
using Datos;
using WASS_SAPTFI.ViewModels.Tramite;
using WASS_SAPTFI.ViewModels.Persona;


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
        // TramiteVM tiene los datos para crear un tramite: Lista de Personas, Tipos de Tramite
        public ActionResult Create()
        {
            TramiteVM model = new TramiteVM();

            //TIPOS DE TRAMITE
            model.Lista_Tipos_Tramite = db.Tipos_Tramites.ToList();

         /*       var lista = db.Tipos_Tramites.Select(tt => new SelectListItem
            {
                Value = tt.Id.ToString(),
                Text = tt.Descripcion
            });

                model.Lista_Tipos_Tramite = lista;    */


            model.Lista_Personas = new List<PersonaVM>();

            //PERSONAS PARA LA LISTA
            foreach(Persona p in db.Personas)
            {
                PersonaVM pVM = new PersonaVM();
                pVM.Id = p.Id;
                pVM.NombreYapellido = p.NombreYapellido;
                pVM.DNI = p.DNI;
                pVM.Tipo_Persona = p.Tipo_Persona;
                
                model.Lista_Personas.Add(pVM);
            }

            //ESTADOS
            model.Estados = db.Estados.ToList();
            return PartialView("_AltaTramite",model);
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

       public ActionResult ListarTramites()
        {
            //Armo la lista
            List<ListaTramiteVM> listaTramites = new List<ListaTramiteVM>();
            listaTramites.Clear();
            
           //Para cada uno de los tramites
            foreach (Tramite itemLista in db.Tramites.ToList())
            {
                ListaTramiteVM ltvm = new ListaTramiteVM();

            //Mapeo los datos entre los tramites y el TramiteViewModel
                ltvm.Id = itemLista.Id;
                ltvm.DNI = itemLista.Persona.DNI;
                ltvm.NombreYapellido = itemLista.Persona.NombreYapellido;
                itemLista.Detalles_Tramite.ToList();
                //Obtengo la descripción correspondiente a la ultima fecha y la fecha
                 foreach (Detalles_Tramite dt in itemLista.Detalles_Tramite.ToList())
                 {
                     //Si la fecha del detalle es la ultima, me quedo con el dato descripcion y fecha
                     if (dt.Fecha_Desde == dt.Tramite.Detalles_Tramite.OrderByDescending(dddt => dddt.Fecha_Desde).FirstOrDefault().Fecha_Desde)
                         //itemLista.Detalles_Tramite.ToList().OrderByDescending(ddt => ddt.Fecha_Desde).ToList().FirstOrDefault().Fecha_Desde)
                     {
                         ltvm.Ultimo_Detalle = dt.Descripcion;
                         ltvm.Ultimo_Movimiento = dt.Fecha_Desde;
                     }
                 }

                //Lo añado a la lista
                listaTramites.Add(ltvm);

            }

            //Corro la vista parcial _ListaTramites
            return PartialView("_ListaTramites", listaTramites);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}