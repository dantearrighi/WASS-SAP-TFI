using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Modelos;

namespace WASS_SAPTFI.ViewModels.Tramite
{
    public class TramiteVM
    {
     

        public List<Tipo_Tramite> Lista_Tipos_Tramite { get; set; }
        
        public List<Persona> Lista_Personas{ get; set; }

        public List<Detalles_Tramite> Lista_Detalles_Tramite { get; set; }

        public List<Expediente> Lista_Expedientes { get; set; }

        public List<Estado> Estados { get; set; }




       
        
    }
}