using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WASS_SAPTFI.ViewModels.Tramite
{
    public class ListaTramiteVM
    {
        public int Id { get; set; }

        public string DNI { get; set; }

        public string NombreYapellido { get; set; }

        public string Ultimo_Detalle { get; set; }

        public DateTime Ultimo_Movimiento  { get; set; }
    }
}