﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modelos
{
  public  class Calculo
    {
        [Key]
        public int Id { get; set; }

        public int idTramite { get; set; }

        public string Descripcion { get; set; }

        
        public Tipo_Calculo Tipo_de_Calculo{ get; set; }




    }
}
