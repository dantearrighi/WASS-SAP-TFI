using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
  public  class Tramite
    {
        public int Id { get; set; }
        public Tipo_Tramite Tipo_Tramite { get; set; }
        public ICollection<Expediente> Expedientes { get; set; }
        public ICollection<Calculo> Calculos{ get; set; }
    }
}
