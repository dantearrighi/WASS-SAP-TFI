namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tramite", "IdPersona");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tramite", "IdPersona", c => c.Int(nullable: false));
        }
    }
}
