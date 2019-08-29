namespace HBSIS.TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "Email", c => c.String());
            DropColumn("dbo.Usuarios", "MoraFora");
            DropColumn("dbo.Usuarios", "Gestor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Gestor", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "MoraFora", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "Email", c => c.String(nullable: false));
        }
    }
}
