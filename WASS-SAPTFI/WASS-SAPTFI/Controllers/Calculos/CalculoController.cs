using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WASS_SAPTFI.Controllers.Calculos
{
    public class CalculoController : Controller
    {




        //
        // GET: /Tramite/

        public ActionResult Index()
        {
            return View(db.Tramites.ToList());
        }





        //VARIABLES

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
