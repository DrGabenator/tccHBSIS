namespace HBSIS.TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBquatro : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Periodoes", new[] { "usuario_IdRegistrarion" });
            DropIndex("dbo.Vagas", new[] { "usuario_IdRegistrarion" });
            CreateIndex("dbo.Periodoes", "Usuario_IdRegistrarion");
            CreateIndex("dbo.Vagas", "Usuario_IdRegistrarion");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vagas", new[] { "Usuario_IdRegistrarion" });
            DropIndex("dbo.Periodoes", new[] { "Usuario_IdRegistrarion" });
            CreateIndex("dbo.Vagas", "usuario_IdRegistrarion");
            CreateIndex("dbo.Periodoes", "usuario_IdRegistrarion");
        }
    }
}
