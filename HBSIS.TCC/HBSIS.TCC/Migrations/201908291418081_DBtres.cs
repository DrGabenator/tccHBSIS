namespace HBSIS.TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBtres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TermoDeUsoes", "usuario_IdRegistrarion", "dbo.Usuarios");
            DropIndex("dbo.TermoDeUsoes", new[] { "usuario_IdRegistrarion" });
            DropColumn("dbo.TermoDeUsoes", "usuario_IdRegistrarion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TermoDeUsoes", "usuario_IdRegistrarion", c => c.Int());
            CreateIndex("dbo.TermoDeUsoes", "usuario_IdRegistrarion");
            AddForeignKey("dbo.TermoDeUsoes", "usuario_IdRegistrarion", "dbo.Usuarios", "IdRegistrarion");
        }
    }
}
