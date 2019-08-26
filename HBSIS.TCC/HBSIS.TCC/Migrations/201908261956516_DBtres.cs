namespace HBSIS.TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBtres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Automovels", "marcaAutomovel_Codigo", "dbo.MarcaAutomovels");
            DropForeignKey("dbo.Automovels", "modeloAutomovel_Codigo", "dbo.ModeloAutomovels");
            DropForeignKey("dbo.Locacaos", "registroVeiculo_Codigo", "dbo.RegistroVeiculoes");
            DropForeignKey("dbo.TipoVeiculoes", "automovel_Codigo", "dbo.Automovels");
            DropForeignKey("dbo.TipoVeiculoes", "bicicleta_Codigo", "dbo.Bicicletas");
            DropForeignKey("dbo.TipoVeiculoes", "moto_Codigo", "dbo.Motoes");
            DropForeignKey("dbo.TipoVeiculoes", "patinete_Codigo", "dbo.Patinetes");
            DropForeignKey("dbo.Motoes", "marcaMoto_Codigo", "dbo.MarcaMotoes");
            DropForeignKey("dbo.Motoes", "modeloMoto_Codigo", "dbo.ModeloMotoes");
            DropIndex("dbo.Automovels", new[] { "marcaAutomovel_Codigo" });
            DropIndex("dbo.Automovels", new[] { "modeloAutomovel_Codigo" });
            DropIndex("dbo.Locacaos", new[] { "registroVeiculo_Codigo" });
            DropIndex("dbo.RegistroVeiculoes", new[] { "tipoVeiculo_Id" });
            DropIndex("dbo.TipoVeiculoes", new[] { "automovel_Codigo" });
            DropIndex("dbo.TipoVeiculoes", new[] { "bicicleta_Codigo" });
            DropIndex("dbo.TipoVeiculoes", new[] { "moto_Codigo" });
            DropIndex("dbo.TipoVeiculoes", new[] { "patinete_Codigo" });
            DropIndex("dbo.Motoes", new[] { "marcaMoto_Codigo" });
            DropIndex("dbo.Motoes", new[] { "modeloMoto_Codigo" });
            AddColumn("dbo.MarcaAutomovels", "Descricao", c => c.String());
            AddColumn("dbo.Motoes", "ModeloMotoFK", c => c.Int(nullable: false));
            AlterColumn("dbo.Automovels", "MarcaAutomovel_Codigo", c => c.Int(nullable: false));
            AlterColumn("dbo.Automovels", "ModeloAutomovel_Codigo", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "RegistroVeiculo_Codigo", c => c.Int(nullable: false));
            AlterColumn("dbo.TipoVeiculoes", "Automovel_Codigo", c => c.Int(nullable: false));
            AlterColumn("dbo.TipoVeiculoes", "Bicicleta_Codigo", c => c.Int(nullable: false));
            AlterColumn("dbo.TipoVeiculoes", "Moto_Codigo", c => c.Int(nullable: false));
            AlterColumn("dbo.TipoVeiculoes", "Patinete_Codigo", c => c.Int(nullable: false));
            AlterColumn("dbo.Motoes", "MarcaMoto_Codigo", c => c.Int(nullable: false));
            AlterColumn("dbo.Motoes", "ModeloMoto_Codigo", c => c.Int(nullable: false));
            CreateIndex("dbo.Automovels", "MarcaAutomovel_Codigo");
            CreateIndex("dbo.Automovels", "ModeloAutomovel_Codigo");
            CreateIndex("dbo.Locacaos", "RegistroVeiculo_Codigo");
            CreateIndex("dbo.RegistroVeiculoes", "TipoVeiculo_Id");
            CreateIndex("dbo.TipoVeiculoes", "Automovel_Codigo");
            CreateIndex("dbo.TipoVeiculoes", "Bicicleta_Codigo");
            CreateIndex("dbo.TipoVeiculoes", "Moto_Codigo");
            CreateIndex("dbo.TipoVeiculoes", "Patinete_Codigo");
            CreateIndex("dbo.Motoes", "MarcaMoto_Codigo");
            CreateIndex("dbo.Motoes", "ModeloMoto_Codigo");
            AddForeignKey("dbo.Automovels", "MarcaAutomovel_Codigo", "dbo.MarcaAutomovels", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.Automovels", "ModeloAutomovel_Codigo", "dbo.ModeloAutomovels", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.Locacaos", "RegistroVeiculo_Codigo", "dbo.RegistroVeiculoes", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.TipoVeiculoes", "Automovel_Codigo", "dbo.Automovels", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.TipoVeiculoes", "Bicicleta_Codigo", "dbo.Bicicletas", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.TipoVeiculoes", "Moto_Codigo", "dbo.Motoes", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.TipoVeiculoes", "Patinete_Codigo", "dbo.Patinetes", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.Motoes", "MarcaMoto_Codigo", "dbo.MarcaMotoes", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.Motoes", "ModeloMoto_Codigo", "dbo.ModeloMotoes", "Codigo", cascadeDelete: true);
            DropColumn("dbo.MarcaAutomovels", "Descricaco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MarcaAutomovels", "Descricaco", c => c.String());
            DropForeignKey("dbo.Motoes", "ModeloMoto_Codigo", "dbo.ModeloMotoes");
            DropForeignKey("dbo.Motoes", "MarcaMoto_Codigo", "dbo.MarcaMotoes");
            DropForeignKey("dbo.TipoVeiculoes", "Patinete_Codigo", "dbo.Patinetes");
            DropForeignKey("dbo.TipoVeiculoes", "Moto_Codigo", "dbo.Motoes");
            DropForeignKey("dbo.TipoVeiculoes", "Bicicleta_Codigo", "dbo.Bicicletas");
            DropForeignKey("dbo.TipoVeiculoes", "Automovel_Codigo", "dbo.Automovels");
            DropForeignKey("dbo.Locacaos", "RegistroVeiculo_Codigo", "dbo.RegistroVeiculoes");
            DropForeignKey("dbo.Automovels", "ModeloAutomovel_Codigo", "dbo.ModeloAutomovels");
            DropForeignKey("dbo.Automovels", "MarcaAutomovel_Codigo", "dbo.MarcaAutomovels");
            DropIndex("dbo.Motoes", new[] { "ModeloMoto_Codigo" });
            DropIndex("dbo.Motoes", new[] { "MarcaMoto_Codigo" });
            DropIndex("dbo.TipoVeiculoes", new[] { "Patinete_Codigo" });
            DropIndex("dbo.TipoVeiculoes", new[] { "Moto_Codigo" });
            DropIndex("dbo.TipoVeiculoes", new[] { "Bicicleta_Codigo" });
            DropIndex("dbo.TipoVeiculoes", new[] { "Automovel_Codigo" });
            DropIndex("dbo.RegistroVeiculoes", new[] { "TipoVeiculo_Id" });
            DropIndex("dbo.Locacaos", new[] { "RegistroVeiculo_Codigo" });
            DropIndex("dbo.Automovels", new[] { "ModeloAutomovel_Codigo" });
            DropIndex("dbo.Automovels", new[] { "MarcaAutomovel_Codigo" });
            AlterColumn("dbo.Motoes", "ModeloMoto_Codigo", c => c.Int());
            AlterColumn("dbo.Motoes", "MarcaMoto_Codigo", c => c.Int());
            AlterColumn("dbo.TipoVeiculoes", "Patinete_Codigo", c => c.Int());
            AlterColumn("dbo.TipoVeiculoes", "Moto_Codigo", c => c.Int());
            AlterColumn("dbo.TipoVeiculoes", "Bicicleta_Codigo", c => c.Int());
            AlterColumn("dbo.TipoVeiculoes", "Automovel_Codigo", c => c.Int());
            AlterColumn("dbo.Locacaos", "RegistroVeiculo_Codigo", c => c.Int());
            AlterColumn("dbo.Automovels", "ModeloAutomovel_Codigo", c => c.Int());
            AlterColumn("dbo.Automovels", "MarcaAutomovel_Codigo", c => c.Int());
            DropColumn("dbo.Motoes", "ModeloMotoFK");
            DropColumn("dbo.MarcaAutomovels", "Descricao");
            CreateIndex("dbo.Motoes", "modeloMoto_Codigo");
            CreateIndex("dbo.Motoes", "marcaMoto_Codigo");
            CreateIndex("dbo.TipoVeiculoes", "patinete_Codigo");
            CreateIndex("dbo.TipoVeiculoes", "moto_Codigo");
            CreateIndex("dbo.TipoVeiculoes", "bicicleta_Codigo");
            CreateIndex("dbo.TipoVeiculoes", "automovel_Codigo");
            CreateIndex("dbo.RegistroVeiculoes", "tipoVeiculo_Id");
            CreateIndex("dbo.Locacaos", "registroVeiculo_Codigo");
            CreateIndex("dbo.Automovels", "modeloAutomovel_Codigo");
            CreateIndex("dbo.Automovels", "marcaAutomovel_Codigo");
            AddForeignKey("dbo.Motoes", "modeloMoto_Codigo", "dbo.ModeloMotoes", "Codigo");
            AddForeignKey("dbo.Motoes", "marcaMoto_Codigo", "dbo.MarcaMotoes", "Codigo");
            AddForeignKey("dbo.TipoVeiculoes", "patinete_Codigo", "dbo.Patinetes", "Codigo");
            AddForeignKey("dbo.TipoVeiculoes", "moto_Codigo", "dbo.Motoes", "Codigo");
            AddForeignKey("dbo.TipoVeiculoes", "bicicleta_Codigo", "dbo.Bicicletas", "Codigo");
            AddForeignKey("dbo.TipoVeiculoes", "automovel_Codigo", "dbo.Automovels", "Codigo");
            AddForeignKey("dbo.Locacaos", "registroVeiculo_Codigo", "dbo.RegistroVeiculoes", "Codigo");
            AddForeignKey("dbo.Automovels", "modeloAutomovel_Codigo", "dbo.ModeloAutomovels", "Codigo");
            AddForeignKey("dbo.Automovels", "marcaAutomovel_Codigo", "dbo.MarcaAutomovels", "Codigo");
        }
    }
}
