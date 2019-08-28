namespace HBSIS.TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBcinco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locacaos", "Periodo_Codigo", "dbo.Periodoes");
            DropForeignKey("dbo.Locacaos", "RegistroVeiculo_Codigo", "dbo.RegistroVeiculoes");
            DropForeignKey("dbo.RegistroVeiculoes", "Cor_Codigo", "dbo.Cors");
            DropForeignKey("dbo.RegistroVeiculoes", "Modelo_Codigo", "dbo.Modeloes");
            DropForeignKey("dbo.Modeloes", "Marca_Codigo", "dbo.Marcas");
            DropIndex("dbo.Locacaos", new[] { "Periodo_Codigo" });
            DropIndex("dbo.Locacaos", new[] { "RegistroVeiculo_Codigo" });
            DropIndex("dbo.RegistroVeiculoes", new[] { "Cor_Codigo" });
            DropIndex("dbo.RegistroVeiculoes", new[] { "Modelo_Codigo" });
            DropIndex("dbo.Modeloes", new[] { "Marca_Codigo" });
            AddColumn("dbo.Locacaos", "StatusLocacao", c => c.Int(nullable: false));
            AddColumn("dbo.Locacaos", "Usuario_IdRegistrarion", c => c.Int(nullable: false));
            AddColumn("dbo.RegistroVeiculoes", "Descricao", c => c.String());
            AddColumn("dbo.Modeloes", "Descricao", c => c.String());
            AddColumn("dbo.Modeloes", "Ativo", c => c.Boolean());
            AddColumn("dbo.Modeloes", "UsuInc", c => c.Int());
            AddColumn("dbo.Modeloes", "UsuAlt", c => c.Int());
            AddColumn("dbo.Modeloes", "DatInc", c => c.DateTime());
            AddColumn("dbo.Modeloes", "DatAlt", c => c.DateTime());
            AddColumn("dbo.Marcas", "Descricao", c => c.String());
            AlterColumn("dbo.Locacaos", "Periodo_Codigo", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "RegistroVeiculo_Codigo", c => c.Int(nullable: false));
            AlterColumn("dbo.RegistroVeiculoes", "Cor_Codigo", c => c.Int(nullable: false));
            AlterColumn("dbo.RegistroVeiculoes", "Modelo_Codigo", c => c.Int(nullable: false));
            AlterColumn("dbo.Modeloes", "Marca_Codigo", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuarios", "Email", c => c.String(nullable: false));
            CreateIndex("dbo.Locacaos", "Periodo_Codigo");
            CreateIndex("dbo.Locacaos", "RegistroVeiculo_Codigo");
            CreateIndex("dbo.Locacaos", "Usuario_IdRegistrarion");
            CreateIndex("dbo.RegistroVeiculoes", "Cor_Codigo");
            CreateIndex("dbo.RegistroVeiculoes", "Modelo_Codigo");
            CreateIndex("dbo.Modeloes", "Marca_Codigo");
            AddForeignKey("dbo.Locacaos", "Usuario_IdRegistrarion", "dbo.Usuarios", "IdRegistrarion", cascadeDelete: true);
            AddForeignKey("dbo.Locacaos", "Periodo_Codigo", "dbo.Periodoes", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.Locacaos", "RegistroVeiculo_Codigo", "dbo.RegistroVeiculoes", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.RegistroVeiculoes", "Cor_Codigo", "dbo.Cors", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.RegistroVeiculoes", "Modelo_Codigo", "dbo.Modeloes", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.Modeloes", "Marca_Codigo", "dbo.Marcas", "Codigo", cascadeDelete: true);
            DropColumn("dbo.RegistroVeiculoes", "Descricaco");
            DropColumn("dbo.Modeloes", "Descricaco");
            DropColumn("dbo.Marcas", "Descricacao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Marcas", "Descricacao", c => c.String());
            AddColumn("dbo.Modeloes", "Descricaco", c => c.String());
            AddColumn("dbo.RegistroVeiculoes", "Descricaco", c => c.String());
            DropForeignKey("dbo.Modeloes", "Marca_Codigo", "dbo.Marcas");
            DropForeignKey("dbo.RegistroVeiculoes", "Modelo_Codigo", "dbo.Modeloes");
            DropForeignKey("dbo.RegistroVeiculoes", "Cor_Codigo", "dbo.Cors");
            DropForeignKey("dbo.Locacaos", "RegistroVeiculo_Codigo", "dbo.RegistroVeiculoes");
            DropForeignKey("dbo.Locacaos", "Periodo_Codigo", "dbo.Periodoes");
            DropForeignKey("dbo.Locacaos", "Usuario_IdRegistrarion", "dbo.Usuarios");
            DropIndex("dbo.Modeloes", new[] { "Marca_Codigo" });
            DropIndex("dbo.RegistroVeiculoes", new[] { "Modelo_Codigo" });
            DropIndex("dbo.RegistroVeiculoes", new[] { "Cor_Codigo" });
            DropIndex("dbo.Locacaos", new[] { "Usuario_IdRegistrarion" });
            DropIndex("dbo.Locacaos", new[] { "RegistroVeiculo_Codigo" });
            DropIndex("dbo.Locacaos", new[] { "Periodo_Codigo" });
            AlterColumn("dbo.Usuarios", "Email", c => c.String());
            AlterColumn("dbo.Modeloes", "Marca_Codigo", c => c.Int());
            AlterColumn("dbo.RegistroVeiculoes", "Modelo_Codigo", c => c.Int());
            AlterColumn("dbo.RegistroVeiculoes", "Cor_Codigo", c => c.Int());
            AlterColumn("dbo.Locacaos", "RegistroVeiculo_Codigo", c => c.Int());
            AlterColumn("dbo.Locacaos", "Periodo_Codigo", c => c.Int());
            DropColumn("dbo.Marcas", "Descricao");
            DropColumn("dbo.Modeloes", "DatAlt");
            DropColumn("dbo.Modeloes", "DatInc");
            DropColumn("dbo.Modeloes", "UsuAlt");
            DropColumn("dbo.Modeloes", "UsuInc");
            DropColumn("dbo.Modeloes", "Ativo");
            DropColumn("dbo.Modeloes", "Descricao");
            DropColumn("dbo.RegistroVeiculoes", "Descricao");
            DropColumn("dbo.Locacaos", "Usuario_IdRegistrarion");
            DropColumn("dbo.Locacaos", "StatusLocacao");
            CreateIndex("dbo.Modeloes", "Marca_Codigo");
            CreateIndex("dbo.RegistroVeiculoes", "Modelo_Codigo");
            CreateIndex("dbo.RegistroVeiculoes", "Cor_Codigo");
            CreateIndex("dbo.Locacaos", "RegistroVeiculo_Codigo");
            CreateIndex("dbo.Locacaos", "Periodo_Codigo");
            AddForeignKey("dbo.Modeloes", "Marca_Codigo", "dbo.Marcas", "Codigo");
            AddForeignKey("dbo.RegistroVeiculoes", "Modelo_Codigo", "dbo.Modeloes", "Codigo");
            AddForeignKey("dbo.RegistroVeiculoes", "Cor_Codigo", "dbo.Cors", "Codigo");
            AddForeignKey("dbo.Locacaos", "RegistroVeiculo_Codigo", "dbo.RegistroVeiculoes", "Codigo");
            AddForeignKey("dbo.Locacaos", "Periodo_Codigo", "dbo.Periodoes", "Codigo");
        }
    }
}
