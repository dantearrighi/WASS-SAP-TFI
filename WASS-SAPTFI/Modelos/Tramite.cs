using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Modelos
{
  public  class Tramite
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public Tipo_Tramite Tipo_Tramite { get; set; }
        public ICollection<Expediente> Expedientes { get; set; }
        public ICollection<Calculo> Calculos{ get; set; }

        public ICollection<Detalles_Tramite> Detalles_Tramite{ get; set; }
        
    }
}
