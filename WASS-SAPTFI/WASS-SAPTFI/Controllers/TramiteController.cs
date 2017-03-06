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
        Detalle_TramiteVM dtvm = new Detalle_TramiteVM();








        #region /-/-/-/-/-/-/-/-/---->              G E S T I O N A R   T R A M I T E S              <----/-/-/-/-/-/-/-/-/-/


        public ActionResult Autocomplete(string term)
        {
            
            var model = ObtenerListaTramites()
                .Where(p => p.NombreYapellido.StartsWith(term))
                .Take(10)
                .Select(p => new
                {
                    label = p.NombreYapellido
                });

           

            return Json(model, JsonRequestBehavior.AllowGet);
        }










        //------------> LISTA de Tramites 
        //(Muestra todos los tramites, el ultimo movimiento y la fecha, dni y nombre de la persona)
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
                    {
                        ltvm.Ultimo_Detalle = dt.Descripcion;
                        ltvm.Ultimo_Movimiento = dt.Fecha_Desde;
                    }
                }

                ltvm.Tipo_Tramite = itemLista.Tipo_Tramite.Descripcion;

                //Lo añado a la lista
                listaTramites.Add(ltvm);

            }


            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListaTramites", listaTramites);
            }

            //Corro la vista parcial _ListaTramites
            return PartialView("_ListaTramites", listaTramites);
        }



        #endregion



        #region /-/-/-/---->    A L T A   T R A M I T E     <----/-/-/-/



        // GET: /Tramite/Create
        // TramiteVM tiene los datos para crear un tramite: Lista de Personas, Tipos de Tramite
        // CU Gestionar Tramites: El usuario hace click en el boton "AÑADIR"
        public ActionResult Create()
        {
            //CARGO LOS DATOS NECESARIOS EN EL
            CargarTramiteViewModel();
            return View("_AltaTramite", modelAlta);
        }
        
        
        //LISTA DE PERSONAS PARA SELECCIONAR
        public ActionResult BuscarPersona()
        {
            return View("_SeleccionarPersonaLista", db.Personas);
        }

        //SELECCIONAR UNA PERSONA
        public ActionResult SeleccionarPersona(int id)
        {
            Persona oPersona = db.Personas.Find(id);

            CargarTramiteViewModel(oPersona);
            return View("_AltaTramite", modelAlta);
        }
 
        private void CargarTramiteViewModel()
        {
            //TIPOS DE TRAMITE
            modelAlta.Lista_Tipos_Tramite = db.Tipos_Tramites.ToList();
            //ESTADOS
            modelAlta.Estados = db.Estados.ToList();
        }


        //CARGO LOS DATOS QUE NECESITO ENVIAR A LA VISTA ALTA TRAMITE, DESPUES DE HABER SELECCIONADO UNA PERSONA
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
            tramiteNuevo.Tipo_Tramite = db.Tipos_Tramites.ToList().Find(delegate(Tipo_Tramite fTipoTramite)
            {
                return fTipoTramite.Id == pTramite.Tipo_Tramite.Id;
            });

            tramiteNuevo.Fecha_Alta = new DateTime();
            tramiteNuevo.Fecha_Alta = pTramite.Fecha_Alta;

            tramiteNuevo.Enviado_por = pTramite.Enviado_por;
            tramiteNuevo.Derivado_a = pTramite.Derivado_a;

            tramiteNuevo.Detalles_Tramite = new List<Detalles_Tramite>();
            tramiteNuevo.Detalles_Tramite.Add(pTramite.Detalle_Tramite);

            tramiteNuevo.Estado = db.Estados.FirstOrDefault(e => e.Descripcion == "Activo");

            // ESTO ESTA MUY MAL
            if (ModelState.IsValid)
            {
                db.Tramites.Add(tramiteNuevo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if(tramiteNuevo.Persona!= null && tramiteNuevo.Tipo_Tramite != null && tramiteNuevo.Detalles_Tramite != null && tramiteNuevo.Fecha_Alta!=null)
            {
                db.Tramites.Add(tramiteNuevo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            
            CargarTramiteViewModel();
            CargarTramiteViewModel(pTramite.Persona);
            return View("_AltaTramite", modelAlta);

        }
       
        
        /*
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

        */

        #endregion


        public ActionResult ModificarTramite(int id = 0)
        {
            
            Tramite t = db.Tramites.Find(id);
            if (t == null)
            {
                return HttpNotFound();
            }

            CargarDTVMModificarTramite(t);
            
            return View("_ModificarTramite",dtvm);
 
        }

        private void CargarDTVMModificarTramite(Tramite t)
        {
            //Lista de Detalles 
            dtvm.DetallesHistoricos = t.Detalles_Tramite.ToList();

            //Datos Persona
            dtvm.DNI = t.Persona.DNI;
            dtvm.NombreYapellido = t.Persona.NombreYapellido;

            //Datos Tramite
            dtvm.TipoTramiteDescripcion = t.Tipo_Tramite.Descripcion;
            dtvm.IdTramite = t.Id;
            dtvm.Fecha_Alta = t.Fecha_Alta;
        }


        //AÑADIR DETALLE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AñadirDetalle(Detalle_TramiteVM ddttvm)
        {
          
            Tramite t = db.Tramites.Find(ddttvm.IdTramite);

            if (t != null)
            {
                //Añado a la bd el detalle nuevo
                db.Detalles_Tramites.Add(ddttvm.DetalleNuevo);
               //Guardo los cambios
                db.SaveChanges();

                //Al tramite seleccionado, le agrego el detalle ya guardado
                t.Detalles_Tramite.Add(ddttvm.DetalleNuevo);

                //Cambio el estado
              //  db.Entry(t).State = EntityState.Modified;

                //Guardo los cambios
                db.SaveChanges();

                CargarDTVMModificarTramite(t);
                ModelState.Clear();
                return View("_ModificarTramite",dtvm);
            }
            return RedirectToAction("Index");
        }






        //
        // GET: /Tramite/

        public ActionResult Index(string searchTerm)
        {
           /* var model =  ObtenerListaTramites()
                        .OrderBy(p => p.NombreYapellido)
                        .Where(p => p.NombreYapellido.ToLower().Contains(searchTerm) || searchTerm == null)
                        .Select(p => p);*/

        //    var model = ObtenerListaTramites().Where(ol => ol.NombreYapellido.ToLower().Contains(searchTerm) || searchTerm == null);

            if (Request.IsAjaxRequest())
            {
                 return PartialView("_ListaTramites", ObtenerListaTramites());
            }
            else
            {

                //Corro la vista parcial _ListaTramites
                return View(ObtenerListaTramites());

            }        
            
        }



        public List<ListaTramiteVM> ObtenerListaTramites()
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
                    {
                        ltvm.Ultimo_Detalle = dt.Descripcion;
                        ltvm.Ultimo_Movimiento = dt.Fecha_Desde;
                    }
                }

                ltvm.Tipo_Tramite = itemLista.Tipo_Tramite.Descripcion;

                //Lo añado a la lista
                listaTramites.Add(ltvm);

            }

            return listaTramites;
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
            var detalles = db.Detalles_Tramites
                            .Where(dt => dt.Tramite.Id == id)
                            .Select(dt => dt).ToList();

            foreach (Detalles_Tramite item in detalles)
            {
                db.Detalles_Tramites.Remove(item);
                db.SaveChanges();
            }

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