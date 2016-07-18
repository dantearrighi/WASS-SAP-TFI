using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Es obligatorio ingresar un Nombre y Apellido")]
        public string NombreYapellido { get; set; }

        [Required(ErrorMessage = "Es obligatorio ingresar un número de documento")]
        public string DNI { get; set; }

        
        public Tipo_Documento Tipo_Documento { get; set; }

        
        public Tipo_Persona Tipo_Persona { get; set; }

        [Required(ErrorMessage = "Es obligatorio ingresar la fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Nacimiento { get; set; }

        public string Estado_Civil { get; set; }

        public string Sexo { get; set; }

        [Required(ErrorMessage = "Es obligatorio ingresar un Teléfono. Si no posee, ingrese 0")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Es obligatorio ingresar un Celular. Si no posee, ingrese 0")]
        public string Celular { get; set; }

        [Required]
        [DataType(DataType.EmailAddress,ErrorMessage="Es obligatorio ingresar un Email")]
        public string Email { get; set; }

        public string Clave_Fiscal { get; set; }

        public ICollection<Tramite> Tramites { get; set; }

        public ICollection<Direccion> Direcciones { get; set; }

        public Estado Estado { get; set; }
    }
}
