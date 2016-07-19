using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WASS_SAPTFI.ViewModels.Persona
{
    public class PersonaVM
    {
        public int Id { get; set; }

        [Required]
        public string NombreYapellido { get; set; }

        [Required]
        public string DNI { get; set; }

        public Tipo_Persona Tipo_Persona { get; set; }
    }
}