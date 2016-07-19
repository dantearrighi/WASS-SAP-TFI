using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelos;

namespace WASS_SAPTFI.ViewModels.Tramite
{
    public class Detalle_TramiteVM
    {


        //DATOS DEL DETALLE
        public int Id { get; set; }

        public DateTime Ultimo_Movimiento { get; set; }

        public string Descripcion { get; set; }

        public List<Detalles_Tramite> DetallesHistoricos { get; set; }


        //DATOS DEL TRAMITE
        public int IdTramite { get; set; } //

        public string TipoTramiteDescripcion { get; set; }

        public string NombreYapellido { get; set; }

        public string DNI { get; set; }

        public DateTime Fecha_Alta { get; set; }
    }
}