namespace HBSIS.TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBoito : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TermoDeUsoes", "usuario_IdRegistrarion", c => c.Int());
            CreateIndex("dbo.TermoDeUsoes", "usuario_IdRegistrarion");
            AddForeignKey("dbo.TermoDeUsoes", "usuario_IdRegistrarion", "dbo.Usuarios", "IdRegistrarion");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TermoDeUsoes", "usuario_IdRegistrarion", "dbo.Usuarios");
            DropIndex("dbo.TermoDeUsoes", new[] { "usuario_IdRegistrarion" });
            DropColumn("dbo.TermoDeUsoes", "usuario_IdRegistrarion");
        }
    }
}
