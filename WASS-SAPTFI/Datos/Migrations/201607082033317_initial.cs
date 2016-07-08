namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calculo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Ruta = c.String(),
                        Tramite_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tramite", t => t.Tramite_Id)
                .Index(t => t.Tramite_Id);
            
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DireccionDescripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Documentacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        Tipo_Tramite_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tipo_Tramite", t => t.Tipo_Tramite_Id)
                .Index(t => t.Tipo_Tramite_Id);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expediente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(nullable: false),
                        Tramite_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tramite", t => t.Tramite_Id)
                .Index(t => t.Tramite_Id);
            
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Codigo_Postal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreYapellido = c.String(nullable: false),
                        DNI = c.String(nullable: false),
                        Fecha_Nacimiento = c.DateTime(nullable: false),
                        Estado_Civil = c.String(),
                        Sexo = c.String(),
                        Telefono = c.String(nullable: false),
                        Celular = c.String(),
                        Email = c.String(nullable: false),
                        Clave_Fiscal = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tramite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo_Tramite_Id = c.Int(nullable: false),
                        Persona_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tipo_Tramite", t => t.Tipo_Tramite_Id, cascadeDelete: true)
                .ForeignKey("dbo.Persona", t => t.Persona_Id)
                .Index(t => t.Tipo_Tramite_Id)
                .Index(t => t.Persona_Id);
            
            CreateTable(
                "dbo.Tipo_Tramite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Detalles_Tramite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha_Desde = c.DateTime(nullable: false),
                        IdTramite = c.Int(nullable: false),
                        Tramite_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tramite", t => t.Tramite_Id)
                .Index(t => t.Tramite_Id);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tipo_Documento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tipo_Persona",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(nullable: false),
                        Rol = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Detalles_Tramite", new[] { "Tramite_Id" });
            DropIndex("dbo.Tramite", new[] { "Persona_Id" });
            DropIndex("dbo.Tramite", new[] { "Tipo_Tramite_Id" });
            DropIndex("dbo.Expediente", new[] { "Tramite_Id" });
            DropIndex("dbo.Documentacion", new[] { "Tipo_Tramite_Id" });
            DropIndex("dbo.Calculo", new[] { "Tramite_Id" });
            DropForeignKey("dbo.Detalles_Tramite", "Tramite_Id", "dbo.Tramite");
            DropForeignKey("dbo.Tramite", "Persona_Id", "dbo.Persona");
            DropForeignKey("dbo.Tramite", "Tipo_Tramite_Id", "dbo.Tipo_Tramite");
            DropForeignKey("dbo.Expediente", "Tramite_Id", "dbo.Tramite");
            DropForeignKey("dbo.Documentacion", "Tipo_Tramite_Id", "dbo.Tipo_Tramite");
            DropForeignKey("dbo.Calculo", "Tramite_Id", "dbo.Tramite");
            DropTable("dbo.Usuario");
            DropTable("dbo.Tipo_Persona");
            DropTable("dbo.Tipo_Documento");
            DropTable("dbo.Provincia");
            DropTable("dbo.Detalles_Tramite");
            DropTable("dbo.Tipo_Tramite");
            DropTable("dbo.Tramite");
            DropTable("dbo.Persona");
            DropTable("dbo.Localidad");
            DropTable("dbo.Expediente");
            DropTable("dbo.Estado");
            DropTable("dbo.Documentacion");
            DropTable("dbo.Direccion");
            DropTable("dbo.Calculo");
        }
    }
}
