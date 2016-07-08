using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Persona
    {
        public int Id { get; set; }
        public string NombreYapellido { get; set; }
        public string DNI { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Estado_Civil { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Clave_Fiscal { get; set; }
        public ICollection<Tramite> Tramites { get; set; }

    }
}
