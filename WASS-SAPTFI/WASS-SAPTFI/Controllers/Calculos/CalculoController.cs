using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WASS_SAPTFI.ViewModels.Calculo;

namespace WASS_SAPTFI.Controllers.Calculos
{
    public class CalculoController : Controller
    {

        


        //
        // GET: /Calculos/RealizarCalculo/id

        public ActionResult Index(int id = 0)
        {
            //Obtengo el tramite al cual le voy a realizar el cálculo
            calculovm.Tramite = db.Tramites.Find(id);
            if (calculovm.Tramite == null)
            {
                return HttpNotFound();
            }
            
            return View("_AltaCalculo",calculovm);
        }





        //VARIABLES
        private WASSDbContext db = new WASSDbContext();
        CalculoVM calculovm = new CalculoVM();
        private DatosCalculo _datos = new DatosCalculo();
        private CalculoStrategy _calculoStrategy;
        

        //SETEAR TIPO DE CALCULO --> Cual strategy utilizo (CalculoStrategy)
        public void SetCalculoStrategy(CalculoStrategy _Pcalculostrategy)
        {
            this._calculoStrategy = _Pcalculostrategy;
        }

        
        //ACCION CALCULAR
        public DatosCalculo Calcular(DatosCalculo _datos)
        {
            return _calculoStrategy.RealizarCalculo(_datos);

        }


    }
}
