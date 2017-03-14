using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos
{
  public  class Tramite
    {
        [Key]
        public int Id { get; set; }
      
       [Required]
        public virtual Tipo_Tramite Tipo_Tramite { get; set; }

       public DateTime Fecha_Alta { get; set; }

       public string Enviado_por { get; set; }

       public string Derivado_a { get; set; }
        public virtual ICollection<Expediente> Expedientes { get; set; }
        public virtual ICollection<Calculo> Calculos{ get; set; }

        public virtual ICollection<Detalles_Tramite> Detalles_Tramite { get; set; }

        public virtual ICollection<Tipo_Calculo> Tipos_de_Calculos { get; set; }
      
        public virtual Estado Estado { get; set; }
        
        public virtual Persona Persona { get; set; }
        
    }
}
