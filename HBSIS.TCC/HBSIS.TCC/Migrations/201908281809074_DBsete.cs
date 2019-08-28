namespace HBSIS.TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBsete : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TermoDeUsoes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Termo = c.String(),
                        Ativo = c.Boolean(),
                        UsuInc = c.Int(),
                        UsuAlt = c.Int(),
                        DatInc = c.DateTime(),
                        DatAlt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            AddColumn("dbo.Usuarios", "Gestor", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Gestor");
            DropTable("dbo.TermoDeUsoes");
        }
    }
}
