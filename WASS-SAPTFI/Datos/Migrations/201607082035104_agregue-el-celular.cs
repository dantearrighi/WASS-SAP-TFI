namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregueelcelular : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Persona", "Celular", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Persona", "Celular", c => c.String());
        }
    }
}
