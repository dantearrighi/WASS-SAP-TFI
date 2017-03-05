using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Detalles_Tramite
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Es obligatorio ingresar una descripción del movimiento.")]
        public string Descripcion { get; set; }

        
        [Required(ErrorMessage = "Es obligatorio ingresar la fecha del movimiento.")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Desde { get; set; }

        public virtual Tramite Tramite { get; set; }


    }
}
