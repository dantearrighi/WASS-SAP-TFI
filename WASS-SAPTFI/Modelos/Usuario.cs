using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modelos
{
  public  class Usuario
    {
      [Key]
        public int Id { get; set; }

      [Required]
        public string NombreUsuario { get; set; }
      [Required]  
      public string Rol { get; set; }
    }
}
