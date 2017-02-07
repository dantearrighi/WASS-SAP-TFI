using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Modelos;
using WASS_SAPTFI.Controllers.Calculos;

namespace WASS_SAPTFI.ViewModels.Calculo
{
    public class CalculoVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Modelos.Tramite Tramite { get; set; }

        public DatosCalculo DatosCalculo { get; set; }

        public Modelos.Calculo Calculo { get; set; }



    }
}