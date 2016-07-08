namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agreguelaDireccionPersona : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Direccion", "Persona_Id", c => c.Int());
            AddColumn("dbo.Localidad", "Provincia_Id", c => c.Int());
            AddColumn("dbo.Persona", "Tipo_Documento_Id", c => c.Int());
            AddForeignKey("dbo.Direccion", "Persona_Id", "dbo.Persona", "Id");
            AddForeignKey("dbo.Localidad", "Provincia_Id", "dbo.Provincia", "Id");
            AddForeignKey("dbo.Persona", "Tipo_Documento_Id", "dbo.Tipo_Documento", "Id");
            CreateIndex("dbo.Direccion", "Persona_Id");
            CreateIndex("dbo.Localidad", "Provincia_Id");
            CreateIndex("dbo.Persona", "Tipo_Documento_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Persona", new[] { "Tipo_Documento_Id" });
            DropIndex("dbo.Localidad", new[] { "Provincia_Id" });
            DropIndex("dbo.Direccion", new[] { "Persona_Id" });
            DropForeignKey("dbo.Persona", "Tipo_Documento_Id", "dbo.Tipo_Documento");
            DropForeignKey("dbo.Localidad", "Provincia_Id", "dbo.Provincia");
            DropForeignKey("dbo.Direccion", "Persona_Id", "dbo.Persona");
            DropColumn("dbo.Persona", "Tipo_Documento_Id");
            DropColumn("dbo.Localidad", "Provincia_Id");
            DropColumn("dbo.Direccion", "Persona_Id");
        }
    }
}
