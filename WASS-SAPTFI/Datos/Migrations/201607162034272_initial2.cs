namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
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
                        Persona_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.Persona_Id)
                .Index(t => t.Persona_Id);
            
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
                        Provincia_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provincia", t => t.Provincia_Id)
                .Index(t => t.Provincia_Id);
            
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
                        Celular = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Clave_Fiscal = c.String(),
                        Tipo_Documento_Id = c.Int(),
                        Tipo_Persona_Id = c.Int(),
                        Estado_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tipo_Documento", t => t.Tipo_Documento_Id)
                .ForeignKey("dbo.Tipo_Persona", t => t.Tipo_Persona_Id)
                .ForeignKey("dbo.Estado", t => t.Estado_Id)
                .Index(t => t.Tipo_Documento_Id)
                .Index(t => t.Tipo_Persona_Id)
                .Index(t => t.Estado_Id);
            
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
                        Descripcion = c.String(nullable: false),
                        Fecha_Desde = c.DateTime(nullable: false),
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
            DropIndex("dbo.Persona", new[] { "Estado_Id" });
            DropIndex("dbo.Persona", new[] { "Tipo_Persona_Id" });
            DropIndex("dbo.Persona", new[] { "Tipo_Documento_Id" });
            DropIndex("dbo.Localidad", new[] { "Provincia_Id" });
            DropIndex("dbo.Expediente", new[] { "Tramite_Id" });
            DropIndex("dbo.Documentacion", new[] { "Tipo_Tramite_Id" });
            DropIndex("dbo.Direccion", new[] { "Persona_Id" });
            DropIndex("dbo.Calculo", new[] { "Tramite_Id" });
            DropForeignKey("dbo.Detalles_Tramite", "Tramite_Id", "dbo.Tramite");
            DropForeignKey("dbo.Tramite", "Persona_Id", "dbo.Persona");
            DropForeignKey("dbo.Tramite", "Tipo_Tramite_Id", "dbo.Tipo_Tramite");
            DropForeignKey("dbo.Persona", "Estado_Id", "dbo.Estado");
            DropForeignKey("dbo.Persona", "Tipo_Persona_Id", "dbo.Tipo_Persona");
            DropForeignKey("dbo.Persona", "Tipo_Documento_Id", "dbo.Tipo_Documento");
            DropForeignKey("dbo.Localidad", "Provincia_Id", "dbo.Provincia");
            DropForeignKey("dbo.Expediente", "Tramite_Id", "dbo.Tramite");
            DropForeignKey("dbo.Documentacion", "Tipo_Tramite_Id", "dbo.Tipo_Tramite");
            DropForeignKey("dbo.Direccion", "Persona_Id", "dbo.Persona");
            DropForeignKey("dbo.Calculo", "Tramite_Id", "dbo.Tramite");
            DropTable("dbo.Usuario");
            DropTable("dbo.Provincia");
            DropTable("dbo.Detalles_Tramite");
            DropTable("dbo.Tipo_Tramite");
            DropTable("dbo.Tramite");
            DropTable("dbo.Tipo_Persona");
            DropTable("dbo.Tipo_Documento");
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
