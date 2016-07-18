namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CamposENVIADOPORDERIVADOAFECHAALTA : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tramite", "Fecha_Alta", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tramite", "Enviado_por", c => c.String());
            AddColumn("dbo.Tramite", "Derivado_a", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tramite", "Derivado_a");
            DropColumn("dbo.Tramite", "Enviado_por");
            DropColumn("dbo.Tramite", "Fecha_Alta");
        }
    }
}
