namespace HBSIS.TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBcinco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Periodoes", "Usuario_IdRegistrarion", "dbo.Usuarios");
            DropIndex("dbo.Periodoes", new[] { "Usuario_IdRegistrarion" });
            AddColumn("dbo.Periodoes", "TipoVeiculo", c => c.Int(nullable: false));
            DropColumn("dbo.Periodoes", "Usuario_IdRegistrarion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Periodoes", "Usuario_IdRegistrarion", c => c.Int());
            DropColumn("dbo.Periodoes", "TipoVeiculo");
            CreateIndex("dbo.Periodoes", "Usuario_IdRegistrarion");
            AddForeignKey("dbo.Periodoes", "Usuario_IdRegistrarion", "dbo.Usuarios", "IdRegistrarion");
        }
    }
}
