namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agreguealgo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Persona", "Tipo_Persona_Id", c => c.Int());
            AddColumn("dbo.Persona", "Estado_Id", c => c.Int());
            AddForeignKey("dbo.Persona", "Tipo_Persona_Id", "dbo.Tipo_Persona", "Id");
            AddForeignKey("dbo.Persona", "Estado_Id", "dbo.Estado", "Id");
            CreateIndex("dbo.Persona", "Tipo_Persona_Id");
            CreateIndex("dbo.Persona", "Estado_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Persona", new[] { "Estado_Id" });
            DropIndex("dbo.Persona", new[] { "Tipo_Persona_Id" });
            DropForeignKey("dbo.Persona", "Estado_Id", "dbo.Estado");
            DropForeignKey("dbo.Persona", "Tipo_Persona_Id", "dbo.Tipo_Persona");
            DropColumn("dbo.Persona", "Estado_Id");
            DropColumn("dbo.Persona", "Tipo_Persona_Id");
        }
    }
}
