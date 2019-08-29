namespace HBSIS.TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBdois : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locacaos", "Usuario_IdRegistration", "dbo.Usuarios");
            DropForeignKey("dbo.Vagas", "Usuario_IdRegistration", "dbo.Usuarios");
            RenameColumn(table: "dbo.Locacaos", name: "Usuario_IdRegistration", newName: "Usuario_Codigo");
            RenameColumn(table: "dbo.Vagas", name: "Usuario_IdRegistration", newName: "Usuario_Codigo");
            RenameIndex(table: "dbo.Locacaos", name: "IX_Usuario_IdRegistration", newName: "IX_Usuario_Codigo");
            RenameIndex(table: "dbo.Vagas", name: "IX_Usuario_IdRegistration", newName: "IX_Usuario_Codigo");
            DropPrimaryKey("dbo.Usuarios");
            AddColumn("dbo.Locacaos", "AceiteTermoDeUso", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "Codigo", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Usuarios", "IdRegistration", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Usuarios", "Codigo");
            AddForeignKey("dbo.Locacaos", "Usuario_Codigo", "dbo.Usuarios", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.Vagas", "Usuario_Codigo", "dbo.Usuarios", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vagas", "Usuario_Codigo", "dbo.Usuarios");
            DropForeignKey("dbo.Locacaos", "Usuario_Codigo", "dbo.Usuarios");
            DropPrimaryKey("dbo.Usuarios");
            AlterColumn("dbo.Usuarios", "IdRegistration", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Usuarios", "Codigo");
            DropColumn("dbo.Locacaos", "AceiteTermoDeUso");
            AddPrimaryKey("dbo.Usuarios", "IdRegistration");
            RenameIndex(table: "dbo.Vagas", name: "IX_Usuario_Codigo", newName: "IX_Usuario_IdRegistration");
            RenameIndex(table: "dbo.Locacaos", name: "IX_Usuario_Codigo", newName: "IX_Usuario_IdRegistration");
            RenameColumn(table: "dbo.Vagas", name: "Usuario_Codigo", newName: "Usuario_IdRegistration");
            RenameColumn(table: "dbo.Locacaos", name: "Usuario_Codigo", newName: "Usuario_IdRegistration");
            AddForeignKey("dbo.Vagas", "Usuario_IdRegistration", "dbo.Usuarios", "IdRegistration");
            AddForeignKey("dbo.Locacaos", "Usuario_IdRegistration", "dbo.Usuarios", "IdRegistration", cascadeDelete: true);
        }
    }
}
