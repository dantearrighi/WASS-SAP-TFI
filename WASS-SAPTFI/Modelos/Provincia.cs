﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modelos
{
   public class Provincia
    {
       [Key]
        public int Id { get; set; }
       [Required]
       public string Nombre { get; set; }

       public ICollection<Localidad> Localidades{ get; set; }
    }
}
