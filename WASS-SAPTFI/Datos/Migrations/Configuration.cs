namespace Datos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Modelos;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Datos.WASSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Datos.WASSDbContext context)
        {
            context.Personas.AddOrUpdate(p => p.NombreYapellido,
                new Persona
                {
                    NombreYapellido = "Virginia Arrighi",
                    Celular = "3426982233",
                    Clave_Fiscal = "23293",
                    DNI = "38500600",
                    Email = "arrighivirginia@gmail.com",
                    Estado_Civil = "Soltero",
                    Fecha_Nacimiento = Convert.ToDateTime("1993/02/23"),
                    Sexo = "Femenino",
                    Telefono = "",
                },
                 new Persona
                 {
                     NombreYapellido = "Ana Hisi",
                     Celular = "3424404557",
                     Clave_Fiscal = "repodrida81",
                     DNI = "13788510",
                     Email = "anamhisi@gmail.com",
                     Estado_Civil = "Divorciado",
                     Fecha_Nacimiento = Convert.ToDateTime("1960/05/02"),
                     Sexo = "Femenino",
                     Telefono = "",
                 },
                 new Persona
                 {
                     NombreYapellido = "Jacque Fresco",
                     Celular = "93238568",
                     Clave_Fiscal = "tvp",
                     DNI = "1385696",
                     Email = "jfrescotvp@gmail.com",
                     Estado_Civil = "Soltero",
                     Fecha_Nacimiento = Convert.ToDateTime("1910/03/18"),
                     Sexo = "Masculino",
                     Telefono = "",
                     
                 });
            
        }
    }
}
