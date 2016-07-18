using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WASS_SAPTFI.ViewModels.Persona;
using Modelos;
using System.ComponentModel.DataAnnotations;

namespace WASS_SAPTFI.ViewModels.Tramite
{
    public class TramiteVM
    {
     

        public List<Tipo_Tramite> Lista_Tipos_Tramite { get; set; }
        
        public List<PersonaVM> Lista_Personas{ get; set; }

        public List<Detalles_Tramite> Lista_Detalles_Tramite { get; set; }

        public List<Expediente> Lista_Expedientes { get; set; }

        public List<Estado> Estados { get; set; }


        [Required(ErrorMessage = "Es obligatorio ingresar la fecha de Alta")]
        public DateTime Fecha_Alta { get; set; }

        public string Enviado_por { get; set; }


        public string Derivado_a { get; set; }
        [Required(ErrorMessage = "Es obligatorio seleccionar un tipo de trámite")]
        public Estado Estado { get; set; }


        public Tipo_Tramite Tipo_Tramite { get; set; }

        [Required(ErrorMessage="Es obligatorio seleccionar una persona")]
        public Modelos.Persona Persona { get; set; }

        public Detalles_Tramite Detalle_Tramite{ get; set; }




       
        
    }
}