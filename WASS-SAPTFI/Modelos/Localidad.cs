using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modelos
{
   public class Localidad
    {
       [Key]
        public int Id { get; set; }

       [Required]
        public string Nombre { get; set; }

       [Required]
        public int Codigo_Postal { get; set; }
    }
}
