namespace HBSIS.TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBdois : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locacaos", "TermoDeUso_Codigo", c => c.Int());
            CreateIndex("dbo.Locacaos", "TermoDeUso_Codigo");
            AddForeignKey("dbo.Locacaos", "TermoDeUso_Codigo", "dbo.TermoDeUsoes", "Codigo");
            DropColumn("dbo.Locacaos", "TermoDeUso");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locacaos", "TermoDeUso", c => c.String());
            DropForeignKey("dbo.Locacaos", "TermoDeUso_Codigo", "dbo.TermoDeUsoes");
            DropIndex("dbo.Locacaos", new[] { "TermoDeUso_Codigo" });
            DropColumn("dbo.Locacaos", "TermoDeUso_Codigo");
        }
    }
}
