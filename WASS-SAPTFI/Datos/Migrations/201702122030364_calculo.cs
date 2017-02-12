namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calculo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calculo", "idTramite", c => c.Int(nullable: false));
            DropColumn("dbo.Calculo", "Ruta");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Calculo", "Ruta", c => c.String());
            DropColumn("dbo.Calculo", "idTramite");
        }
    }
}
