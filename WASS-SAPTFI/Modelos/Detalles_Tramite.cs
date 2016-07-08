using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modelos
{
  public  class Detalles_Tramite
    {
      [Key]
        public int Id { get; set; }

      [DataType(DataType.DateTime)]
      public DateTime Fecha_Desde { get; set; }

      [Required]
      public int IdTramite { get; set; }
    }
}
