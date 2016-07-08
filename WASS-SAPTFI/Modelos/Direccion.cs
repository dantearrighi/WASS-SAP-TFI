using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modelos
{
  public  class Direccion
    {
      [Key]
        public int Id { get; set; }

      [Required]
        public string DireccionDescripcion { get; set; }
    }
}
