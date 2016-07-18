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


        TramiteVM modelAlta = new TramiteVM();




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
            // TramiteVM model = new TramiteVM();

            CargarTramiteViewModel();
            return View("_AltaTramite", modelAlta);
        }

        private void CargarTramiteViewModel()
        {
            //TIPOS DE TRAMITE
            modelAlta.Lista_Tipos_Tramite = db.Tipos_Tramites.ToList();

            

            //ESTADOS
            modelAlta.Estados = db.Estados.ToList();
        }

        private void CargarTramiteViewModel(Persona pPersona)
        {
            //TIPOS DE TRAMITE
            modelAlta.Lista_Tipos_Tramite = db.Tipos_Tramites.ToList();

            

            //ESTADOS
            modelAlta.Estados = db.Estados.ToList();

            modelAlta.Persona = new Persona();

            modelAlta.Persona.NombreYapellido = pPersona.NombreYapellido;
            modelAlta.Persona.DNI = pPersona.DNI;
            modelAlta.Persona.Id = pPersona.Id;


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarTramite(TramiteVM pTramite)
        {
            Tramite tramiteNuevo = new Tramite();

            tramiteNuevo.Persona = new Persona();
            tramiteNuevo.Persona = db.Personas.ToList().Find(delegate(Persona fPersona)
            {
                return fPersona.DNI == pTramite.Persona.DNI;
            });

            tramiteNuevo.Tipo_Tramite = new Tipo_Tramite();
            tramiteNuevo.Tipo_Tramite = pTramite.Tipo_Tramite;

            tramiteNuevo.Fecha_Alta = new DateTime();
            tramiteNuevo.Fecha_Alta = pTramite.Fecha_Alta;

            tramiteNuevo.Enviado_por = pTramite.Enviado_por;
            tramiteNuevo.Derivado_a = pTramite.Derivado_a;

            tramiteNuevo.Detalles_Tramite = new List<Detalles_Tramite>();
            tramiteNuevo.Detalles_Tramite.Add(pTramite.Detalle_Tramite);

           // if (ModelState.IsValid)
          //  {
                db.Tramites.Add(tramiteNuevo);
                db.SaveChanges();
                return RedirectToAction("Index");
          //  }

        //    return View("_AltaTramite", modelAlta);

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





       public ActionResult BuscarPersona()
       {
           return View("_SeleccionarPersonaLista",db.Personas);
       }



        //Buscar Persona
       public ActionResult SeleccionarPersona(int id)
       {
           Persona oPersona = db.Personas.Find(id);

           CargarTramiteViewModel(oPersona);


           return View("_AltaTramite", modelAlta);
       }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}