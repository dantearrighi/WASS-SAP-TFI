using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

using System.Data.Entity.ModelConfiguration.Conventions;

namespace Datos
{
    public class WASSDbContext : DbContext
    {
        public WASSDbContext() : base("WASSdbContextCS")
        {
        }

        public  DbSet<Calculo> Calculos { get; set; }

        public  DbSet<Direccion> Direcciones { get; set; }

        public  DbSet<Documentacion> Documentaciones { get; set; }

        public  DbSet<Estado> Estados { get; set; }

        public  DbSet<Expediente> Expedientes { get; set; }

        public  DbSet<Localidad> Localidades { get; set; }

        public  DbSet<Persona> Personas { get; set; }

        public  DbSet<Provincia> Provincias { get; set; }

        public  DbSet<Tipo_Documento> Tipos_Documentos { get; set; }

        public  DbSet<Tipo_Tramite> Tipos_Tramites { get; set; }
        public DbSet<Tipo_Persona> Tipos_Persona { get; set; }
        public  DbSet<Tramite> Tramites { get; set; }

        public DbSet<Detalles_Tramite> Detalles_Tramites{ get; set; }

        public  DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
