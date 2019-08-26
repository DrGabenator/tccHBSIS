namespace HBSIS.TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBdois : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Automovels",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        marcaAutomovel_Codigo = c.Int(),
                        modeloAutomovel_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.MarcaAutomovels", t => t.marcaAutomovel_Codigo)
                .ForeignKey("dbo.ModeloAutomovels", t => t.modeloAutomovel_Codigo)
                .Index(t => t.marcaAutomovel_Codigo)
                .Index(t => t.modeloAutomovel_Codigo);
            
            CreateTable(
                "dbo.MarcaAutomovels",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricaco = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.ModeloAutomovels",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Bicicletas",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Cors",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Locacaos",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        DataInicial = c.DateTime(nullable: false),
                        DataFinal = c.DateTime(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TermoDeUso = c.String(),
                        registroVeiculo_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.RegistroVeiculoes", t => t.registroVeiculo_Codigo)
                .Index(t => t.registroVeiculo_Codigo);
            
            CreateTable(
                "dbo.RegistroVeiculoes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Placa = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        Cor_Codigo = c.Int(),
                        tipoVeiculo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Cors", t => t.Cor_Codigo)
                .ForeignKey("dbo.TipoVeiculoes", t => t.tipoVeiculo_Id)
                .Index(t => t.Cor_Codigo)
                .Index(t => t.tipoVeiculo_Id);
            
            CreateTable(
                "dbo.TipoVeiculoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        automovel_Codigo = c.Int(),
                        bicicleta_Codigo = c.Int(),
                        moto_Codigo = c.Int(),
                        patinete_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Automovels", t => t.automovel_Codigo)
                .ForeignKey("dbo.Bicicletas", t => t.bicicleta_Codigo)
                .ForeignKey("dbo.Motoes", t => t.moto_Codigo)
                .ForeignKey("dbo.Patinetes", t => t.patinete_Codigo)
                .Index(t => t.automovel_Codigo)
                .Index(t => t.bicicleta_Codigo)
                .Index(t => t.moto_Codigo)
                .Index(t => t.patinete_Codigo);
            
            CreateTable(
                "dbo.Motoes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        marcaMoto_Codigo = c.Int(),
                        modeloMoto_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.MarcaMotoes", t => t.marcaMoto_Codigo)
                .ForeignKey("dbo.ModeloMotoes", t => t.modeloMoto_Codigo)
                .Index(t => t.marcaMoto_Codigo)
                .Index(t => t.modeloMoto_Codigo);
            
            CreateTable(
                "dbo.MarcaMotoes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.ModeloMotoes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Patinetes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        IdRegistrarion = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        PCD = c.Boolean(nullable: false),
                        TrabalhoNoturno = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdRegistrarion);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locacaos", "registroVeiculo_Codigo", "dbo.RegistroVeiculoes");
            DropForeignKey("dbo.RegistroVeiculoes", "tipoVeiculo_Id", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.TipoVeiculoes", "patinete_Codigo", "dbo.Patinetes");
            DropForeignKey("dbo.TipoVeiculoes", "moto_Codigo", "dbo.Motoes");
            DropForeignKey("dbo.Motoes", "modeloMoto_Codigo", "dbo.ModeloMotoes");
            DropForeignKey("dbo.Motoes", "marcaMoto_Codigo", "dbo.MarcaMotoes");
            DropForeignKey("dbo.TipoVeiculoes", "bicicleta_Codigo", "dbo.Bicicletas");
            DropForeignKey("dbo.TipoVeiculoes", "automovel_Codigo", "dbo.Automovels");
            DropForeignKey("dbo.RegistroVeiculoes", "Cor_Codigo", "dbo.Cors");
            DropForeignKey("dbo.Automovels", "modeloAutomovel_Codigo", "dbo.ModeloAutomovels");
            DropForeignKey("dbo.Automovels", "marcaAutomovel_Codigo", "dbo.MarcaAutomovels");
            DropIndex("dbo.Motoes", new[] { "modeloMoto_Codigo" });
            DropIndex("dbo.Motoes", new[] { "marcaMoto_Codigo" });
            DropIndex("dbo.TipoVeiculoes", new[] { "patinete_Codigo" });
            DropIndex("dbo.TipoVeiculoes", new[] { "moto_Codigo" });
            DropIndex("dbo.TipoVeiculoes", new[] { "bicicleta_Codigo" });
            DropIndex("dbo.TipoVeiculoes", new[] { "automovel_Codigo" });
            DropIndex("dbo.RegistroVeiculoes", new[] { "tipoVeiculo_Id" });
            DropIndex("dbo.RegistroVeiculoes", new[] { "Cor_Codigo" });
            DropIndex("dbo.Locacaos", new[] { "registroVeiculo_Codigo" });
            DropIndex("dbo.Automovels", new[] { "modeloAutomovel_Codigo" });
            DropIndex("dbo.Automovels", new[] { "marcaAutomovel_Codigo" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Patinetes");
            DropTable("dbo.ModeloMotoes");
            DropTable("dbo.MarcaMotoes");
            DropTable("dbo.Motoes");
            DropTable("dbo.TipoVeiculoes");
            DropTable("dbo.RegistroVeiculoes");
            DropTable("dbo.Locacaos");
            DropTable("dbo.Cors");
            DropTable("dbo.Bicicletas");
            DropTable("dbo.ModeloAutomovels");
            DropTable("dbo.MarcaAutomovels");
            DropTable("dbo.Automovels");
        }
    }
}
