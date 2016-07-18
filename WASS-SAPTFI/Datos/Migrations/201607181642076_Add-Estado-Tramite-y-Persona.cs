namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEstadoTramiteyPersona : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tramite", "Estado_Id", c => c.Int());
            AddForeignKey("dbo.Tramite", "Estado_Id", "dbo.Estado", "Id");
            CreateIndex("dbo.Tramite", "Estado_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tramite", new[] { "Estado_Id" });
            DropForeignKey("dbo.Tramite", "Estado_Id", "dbo.Estado");
            DropColumn("dbo.Tramite", "Estado_Id");
        }
    }
}
