using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WASS_SAPTFI.Controllers.Calculos
{
    public class DatosCalculo
        {

            //PC
            public decimal PCn { get; set; }
            public decimal PCm { get; set; }
            public decimal PCR { get; set; }
            public decimal PCp { get; set; }
            public decimal PCW { get; set; }
            public decimal PCN { get; set; }
            public decimal PC { get; set; }

            //OTRAS
            public decimal PBU { get; set; }
            public decimal SuplMov { get; set; }
            public decimal HT { get; set; }

            //PAP
            public decimal PAPn { get; set; }
            public decimal PAPm { get; set; }
            public decimal PAPR { get; set; }
            public decimal PAPp { get; set; }
            public decimal PAPW { get; set; }
            public decimal PAPN { get; set; }
            public decimal PAP { get; set; }


            public string txtPrestacionCompensatoria { get; set; }
            public string txtPap { get; set; }

            public string txtHaberVeterano { get; set; }
        }
    }
