using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modelos
{
   public class Tipo_Tramite
    {
       [Key]
        public int Id { get; set; }

       [Required]
        public string Descripcion { get; set; }

        public ICollection<Documentacion> Documentacion_Requerida{ get; set; }
    }
}
