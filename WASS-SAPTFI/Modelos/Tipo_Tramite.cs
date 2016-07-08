using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
   public class Tipo_Tramite
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Documentacion> Documentacion_Requerida{ get; set; }
    }
}
