namespace HBSIS.TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cors",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Ativo = c.Boolean(),
                        UsuInc = c.Int(),
                        UsuAlt = c.Int(),
                        DatInc = c.DateTime(),
                        DatAlt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Locacaos",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StatusLocacao = c.Int(nullable: false),
                        TermoDeUso = c.String(),
                        Ativo = c.Boolean(),
                        UsuInc = c.Int(),
                        UsuAlt = c.Int(),
                        DatInc = c.DateTime(),
                        DatAlt = c.DateTime(),
                        Periodo_Codigo = c.Int(nullable: false),
                        RegistroVeiculo_Codigo = c.Int(nullable: false),
                        Usuario_IdRegistrarion = c.Int(nullable: false),
                        Vaga_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Periodoes", t => t.Periodo_Codigo, cascadeDelete: true)
                .ForeignKey("dbo.RegistroVeiculoes", t => t.RegistroVeiculo_Codigo, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_IdRegistrarion, cascadeDelete: true)
                .ForeignKey("dbo.Vagas", t => t.Vaga_Codigo)
                .Index(t => t.Periodo_Codigo)
                .Index(t => t.RegistroVeiculo_Codigo)
                .Index(t => t.Usuario_IdRegistrarion)
                .Index(t => t.Vaga_Codigo);
            
            CreateTable(
                "dbo.Periodoes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        NumeroDePeriodos = c.Int(nullable: false),
                        DataInicial = c.DateTime(nullable: false),
                        DataFinal = c.DateTime(nullable: false),
                        Ativo = c.Boolean(),
                        UsuInc = c.Int(),
                        UsuAlt = c.Int(),
                        DatInc = c.DateTime(),
                        DatAlt = c.DateTime(),
                        usuario_IdRegistrarion = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Usuarios", t => t.usuario_IdRegistrarion)
                .Index(t => t.usuario_IdRegistrarion);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        IdRegistrarion = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        PCD = c.Boolean(nullable: false),
                        TrabalhoNoturno = c.Boolean(nullable: false),
                        MoraFora = c.Boolean(nullable: false),
                        Gestor = c.Boolean(nullable: false),
                        Ativo = c.Boolean(),
                        UsuInc = c.Int(),
                        UsuAlt = c.Int(),
                        DatInc = c.DateTime(),
                        DatAlt = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdRegistrarion);
            
            CreateTable(
                "dbo.RegistroVeiculoes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Placa = c.String(),
                        Ativo = c.Boolean(),
                        UsuInc = c.Int(),
                        UsuAlt = c.Int(),
                        DatInc = c.DateTime(),
                        DatAlt = c.DateTime(),
                        Cor_Codigo = c.Int(nullable: false),
                        Modelo_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Cors", t => t.Cor_Codigo, cascadeDelete: true)
                .ForeignKey("dbo.Modeloes", t => t.Modelo_Codigo, cascadeDelete: true)
                .Index(t => t.Cor_Codigo)
                .Index(t => t.Modelo_Codigo);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Ativo = c.Boolean(),
                        UsuInc = c.Int(),
                        UsuAlt = c.Int(),
                        DatInc = c.DateTime(),
                        DatAlt = c.DateTime(),
                        Marca_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Marcas", t => t.Marca_Codigo, cascadeDelete: true)
                .Index(t => t.Marca_Codigo);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        TipoVeiculo = c.Int(nullable: false),
                        Ativo = c.Boolean(),
                        UsuInc = c.Int(),
                        UsuAlt = c.Int(),
                        DatInc = c.DateTime(),
                        DatAlt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Vagas",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        VagaAutomovel = c.Int(nullable: false),
                        VagaMoto = c.Int(nullable: false),
                        VagasGeral = c.Int(nullable: false),
                        usuario_IdRegistrarion = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Usuarios", t => t.usuario_IdRegistrarion)
                .Index(t => t.usuario_IdRegistrarion);
            
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
                        usuario_IdRegistrarion = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Usuarios", t => t.usuario_IdRegistrarion)
                .Index(t => t.usuario_IdRegistrarion);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TermoDeUsoes", "usuario_IdRegistrarion", "dbo.Usuarios");
            DropForeignKey("dbo.Locacaos", "Vaga_Codigo", "dbo.Vagas");
            DropForeignKey("dbo.Vagas", "usuario_IdRegistrarion", "dbo.Usuarios");
            DropForeignKey("dbo.Locacaos", "Usuario_IdRegistrarion", "dbo.Usuarios");
            DropForeignKey("dbo.Locacaos", "RegistroVeiculo_Codigo", "dbo.RegistroVeiculoes");
            DropForeignKey("dbo.RegistroVeiculoes", "Modelo_Codigo", "dbo.Modeloes");
            DropForeignKey("dbo.Modeloes", "Marca_Codigo", "dbo.Marcas");
            DropForeignKey("dbo.RegistroVeiculoes", "Cor_Codigo", "dbo.Cors");
            DropForeignKey("dbo.Locacaos", "Periodo_Codigo", "dbo.Periodoes");
            DropForeignKey("dbo.Periodoes", "usuario_IdRegistrarion", "dbo.Usuarios");
            DropIndex("dbo.TermoDeUsoes", new[] { "usuario_IdRegistrarion" });
            DropIndex("dbo.Vagas", new[] { "usuario_IdRegistrarion" });
            DropIndex("dbo.Modeloes", new[] { "Marca_Codigo" });
            DropIndex("dbo.RegistroVeiculoes", new[] { "Modelo_Codigo" });
            DropIndex("dbo.RegistroVeiculoes", new[] { "Cor_Codigo" });
            DropIndex("dbo.Periodoes", new[] { "usuario_IdRegistrarion" });
            DropIndex("dbo.Locacaos", new[] { "Vaga_Codigo" });
            DropIndex("dbo.Locacaos", new[] { "Usuario_IdRegistrarion" });
            DropIndex("dbo.Locacaos", new[] { "RegistroVeiculo_Codigo" });
            DropIndex("dbo.Locacaos", new[] { "Periodo_Codigo" });
            DropTable("dbo.TermoDeUsoes");
            DropTable("dbo.Vagas");
            DropTable("dbo.Marcas");
            DropTable("dbo.Modeloes");
            DropTable("dbo.RegistroVeiculoes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Periodoes");
            DropTable("dbo.Locacaos");
            DropTable("dbo.Cors");
        }
    }
}
