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
            // CARGO PERSONAS
            #region Personas de ejemplo -->

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
                    Telefono = "2323",

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
                     Telefono = "2323",
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
                     Telefono = "2323",
                     

                 });
            #endregion

            //CARGO TIPOS DE PERSONA
            #region Tipos de Persona -->

            context.Tipos_Persona.AddOrUpdate(tp => tp.Descripcion,
                new Tipo_Persona
                {
                    Descripcion = "Abogado",
                },
                new Tipo_Persona
                {
                    Descripcion = "Cliente",
                });
            #endregion

            //CARGO TIPOS DE TRAMITE
            #region Tipos de Tramite -->

            context.Tipos_Tramites.AddOrUpdate(tt => tt.Descripcion,
                new Tipo_Tramite
                {
                    Descripcion = "Jubilación",
                },
                 new Tipo_Tramite
                {
                    Descripcion = "Pensión",
                },
                 new Tipo_Tramite
                {
                    Descripcion = "Pensión Invalidez",
                },
                 new Tipo_Tramite
                {
                    Descripcion = "Reajuste",
                },
                 new Tipo_Tramite
                {
                    Descripcion = "Reconocimiento de servicios",
                },
                 new Tipo_Tramite
                {
                    Descripcion = "Reajuste 24.241",
                },
                 new Tipo_Tramite
                {
                    Descripcion = "Reajuste por error en fecha inicial",
                });
            #endregion

            //CARGO TIPOS DE DOCUMENTO
            #region Tipos de Documento -->

            context.Tipos_Documentos.AddOrUpdate(td => td.Descripcion,
                new Tipo_Documento
                {
                    Descripcion = "DNI",
                },
                new Tipo_Documento
                {
                    Descripcion = "LC",
                },
                new Tipo_Documento
                {
                    Descripcion = "LE",
                },
                new Tipo_Documento
                {
                    Descripcion = "PASAPORTE",
                },
                new Tipo_Documento
                {
                    Descripcion="CEDULA",
                });
            #endregion

            //CARGO PROVINCIAS
            #region Provincias -->
  
            context.Provincias.AddOrUpdate(p => p.Nombre,
                new Provincia
                {
                    Nombre = "Buenos Aires",
                },
                  new Provincia
                {
                    Nombre = "Catamarca",
                },
                  new Provincia
                {
                    Nombre = "Chaco",
                },
                  new Provincia
                {
                    Nombre = "Chubut",
                },
                  new Provincia
                {
                    Nombre = "Córdoba",
                },
                  new Provincia
                {
                    Nombre = "Corrientes",
                },
                  new Provincia
                {
                    Nombre = "Entre Rios",

                },
                  new Provincia
                {
                    Nombre = "Formosa",
                },
                  new Provincia
                {
                    Nombre = "Jujuy",
                },
                  new Provincia
                {
                    Nombre = "La Pampa",
                },
                  new Provincia
                {
                    Nombre = "La Rioja",
                },
                  new Provincia
                {
                    Nombre = "Mendoza",
                },
                  new Provincia
                {
                    Nombre = "Misiones",
                },
                  new Provincia
                {
                    Nombre = "Neuquén",
                },
                  new Provincia
                {
                    Nombre = "Río Negro",
                },
                  new Provincia
                {
                    Nombre = "Salta",
                },
                  new Provincia
                {
                    Nombre = "San Juan",
                },
                  new Provincia
                {
                    Nombre = "San Luis",
                },
                  new Provincia
                {
                    Nombre = "Santa Cruz",
                },
                  new Provincia
                {
                    Nombre = "Santa Fe",
                },
                  new Provincia
                {
                    Nombre = "Santiago del Estero",
                },
                  new Provincia
                {
                    Nombre = "Tierra del Fuego",
                },
                  new Provincia
                {
                    Nombre = "Tucumán",
                },
                  new Provincia
                {
                    Nombre = "Capital Federal",
                });
#endregion

            //CARGO USUARIOS
            #region Usuarios -->
            context.Usuarios.AddOrUpdate(u=> u.NombreUsuario,
               new Usuario
               {
                   NombreUsuario = "adminwass",
                   Rol="Administrador",
               },
               new Usuario
               {
                   NombreUsuario = "invitado",
                   Rol="Invitado",
               });
            #endregion

        }
    }
}
