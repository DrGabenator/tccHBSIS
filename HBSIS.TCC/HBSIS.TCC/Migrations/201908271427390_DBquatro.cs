namespace HBSIS.TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBquatro : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Automovels", "MarcaAutomovel_Codigo", "dbo.MarcaAutomovels");
            DropForeignKey("dbo.Automovels", "ModeloAutomovel_Codigo", "dbo.ModeloAutomovels");
            DropForeignKey("dbo.TipoVeiculoes", "Automovel_Codigo", "dbo.Automovels");
            DropForeignKey("dbo.TipoVeiculoes", "Bicicleta_Codigo", "dbo.Bicicletas");
            DropForeignKey("dbo.Motoes", "MarcaMoto_Codigo", "dbo.MarcaMotoes");
            DropForeignKey("dbo.Motoes", "ModeloMoto_Codigo", "dbo.ModeloMotoes");
            DropForeignKey("dbo.TipoVeiculoes", "Moto_Codigo", "dbo.Motoes");
            DropForeignKey("dbo.TipoVeiculoes", "Patinete_Codigo", "dbo.Patinetes");
            DropForeignKey("dbo.RegistroVeiculoes", "TipoVeiculo_Id", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.Locacaos", "RegistroVeiculo_Codigo", "dbo.RegistroVeiculoes");
            DropIndex("dbo.Automovels", new[] { "MarcaAutomovel_Codigo" });
            DropIndex("dbo.Automovels", new[] { "ModeloAutomovel_Codigo" });
            DropIndex("dbo.Locacaos", new[] { "RegistroVeiculo_Codigo" });
            DropIndex("dbo.RegistroVeiculoes", new[] { "TipoVeiculo_Id" });
            DropIndex("dbo.TipoVeiculoes", new[] { "Automovel_Codigo" });
            DropIndex("dbo.TipoVeiculoes", new[] { "Bicicleta_Codigo" });
            DropIndex("dbo.TipoVeiculoes", new[] { "Moto_Codigo" });
            DropIndex("dbo.TipoVeiculoes", new[] { "Patinete_Codigo" });
            DropIndex("dbo.Motoes", new[] { "MarcaMoto_Codigo" });
            DropIndex("dbo.Motoes", new[] { "ModeloMoto_Codigo" });
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
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricaco = c.String(),
                        Marca_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Marcas", t => t.Marca_Codigo)
                .Index(t => t.Marca_Codigo);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricacao = c.String(),
                        TipoVeiculo = c.Int(nullable: false),
                        Ativo = c.Boolean(),
                        UsuInc = c.Int(),
                        UsuAlt = c.Int(),
                        DatInc = c.DateTime(),
                        DatAlt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            AddColumn("dbo.Cors", "Ativo", c => c.Boolean());
            AddColumn("dbo.Cors", "UsuInc", c => c.Int());
            AddColumn("dbo.Cors", "UsuAlt", c => c.Int());
            AddColumn("dbo.Cors", "DatInc", c => c.DateTime());
            AddColumn("dbo.Cors", "DatAlt", c => c.DateTime());
            AddColumn("dbo.Locacaos", "Vaga", c => c.Int(nullable: false));
            AddColumn("dbo.Locacaos", "Ativo", c => c.Boolean());
            AddColumn("dbo.Locacaos", "UsuInc", c => c.Int());
            AddColumn("dbo.Locacaos", "UsuAlt", c => c.Int());
            AddColumn("dbo.Locacaos", "DatInc", c => c.DateTime());
            AddColumn("dbo.Locacaos", "DatAlt", c => c.DateTime());
            AddColumn("dbo.Locacaos", "Periodo_Codigo", c => c.Int());
            AddColumn("dbo.RegistroVeiculoes", "Descricaco", c => c.String());
            AddColumn("dbo.RegistroVeiculoes", "UsuInc", c => c.Int());
            AddColumn("dbo.RegistroVeiculoes", "UsuAlt", c => c.Int());
            AddColumn("dbo.RegistroVeiculoes", "DatInc", c => c.DateTime());
            AddColumn("dbo.RegistroVeiculoes", "DatAlt", c => c.DateTime());
            AddColumn("dbo.RegistroVeiculoes", "Modelo_Codigo", c => c.Int());
            AddColumn("dbo.Usuarios", "Ativo", c => c.Boolean());
            AddColumn("dbo.Usuarios", "UsuInc", c => c.Int());
            AddColumn("dbo.Usuarios", "UsuAlt", c => c.Int());
            AddColumn("dbo.Usuarios", "DatInc", c => c.DateTime());
            AddColumn("dbo.Usuarios", "DatAlt", c => c.DateTime());
            AlterColumn("dbo.Locacaos", "RegistroVeiculo_Codigo", c => c.Int());
            AlterColumn("dbo.RegistroVeiculoes", "Ativo", c => c.Boolean());
            CreateIndex("dbo.Locacaos", "Periodo_Codigo");
            CreateIndex("dbo.Locacaos", "RegistroVeiculo_Codigo");
            CreateIndex("dbo.RegistroVeiculoes", "Modelo_Codigo");
            AddForeignKey("dbo.Locacaos", "Periodo_Codigo", "dbo.Periodoes", "Codigo");
            AddForeignKey("dbo.RegistroVeiculoes", "Modelo_Codigo", "dbo.Modeloes", "Codigo");
            AddForeignKey("dbo.Locacaos", "RegistroVeiculo_Codigo", "dbo.RegistroVeiculoes", "Codigo");
            DropColumn("dbo.Locacaos", "DataInicial");
            DropColumn("dbo.Locacaos", "DataFinal");
            DropColumn("dbo.RegistroVeiculoes", "TipoVeiculo_Id");
            DropTable("dbo.Automovels");
            DropTable("dbo.MarcaAutomovels");
            DropTable("dbo.ModeloAutomovels");
            DropTable("dbo.Bicicletas");
            DropTable("dbo.TipoVeiculoes");
            DropTable("dbo.Motoes");
            DropTable("dbo.MarcaMotoes");
            DropTable("dbo.ModeloMotoes");
            DropTable("dbo.Patinetes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Patinetes",
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
                "dbo.MarcaMotoes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Motoes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        ModeloMotoFK = c.Int(nullable: false),
                        MarcaMoto_Codigo = c.Int(nullable: false),
                        ModeloMoto_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.TipoVeiculoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Automovel_Codigo = c.Int(nullable: false),
                        Bicicleta_Codigo = c.Int(nullable: false),
                        Moto_Codigo = c.Int(nullable: false),
                        Patinete_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bicicletas",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
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
                "dbo.MarcaAutomovels",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Automovels",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        MarcaAutomovel_Codigo = c.Int(nullable: false),
                        ModeloAutomovel_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            AddColumn("dbo.RegistroVeiculoes", "TipoVeiculo_Id", c => c.Int());
            AddColumn("dbo.Locacaos", "DataFinal", c => c.DateTime(nullable: false));
            AddColumn("dbo.Locacaos", "DataInicial", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Locacaos", "RegistroVeiculo_Codigo", "dbo.RegistroVeiculoes");
            DropForeignKey("dbo.RegistroVeiculoes", "Modelo_Codigo", "dbo.Modeloes");
            DropForeignKey("dbo.Modeloes", "Marca_Codigo", "dbo.Marcas");
            DropForeignKey("dbo.Locacaos", "Periodo_Codigo", "dbo.Periodoes");
            DropIndex("dbo.Modeloes", new[] { "Marca_Codigo" });
            DropIndex("dbo.RegistroVeiculoes", new[] { "Modelo_Codigo" });
            DropIndex("dbo.Locacaos", new[] { "RegistroVeiculo_Codigo" });
            DropIndex("dbo.Locacaos", new[] { "Periodo_Codigo" });
            AlterColumn("dbo.RegistroVeiculoes", "Ativo", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Locacaos", "RegistroVeiculo_Codigo", c => c.Int(nullable: false));
            DropColumn("dbo.Usuarios", "DatAlt");
            DropColumn("dbo.Usuarios", "DatInc");
            DropColumn("dbo.Usuarios", "UsuAlt");
            DropColumn("dbo.Usuarios", "UsuInc");
            DropColumn("dbo.Usuarios", "Ativo");
            DropColumn("dbo.RegistroVeiculoes", "Modelo_Codigo");
            DropColumn("dbo.RegistroVeiculoes", "DatAlt");
            DropColumn("dbo.RegistroVeiculoes", "DatInc");
            DropColumn("dbo.RegistroVeiculoes", "UsuAlt");
            DropColumn("dbo.RegistroVeiculoes", "UsuInc");
            DropColumn("dbo.RegistroVeiculoes", "Descricaco");
            DropColumn("dbo.Locacaos", "Periodo_Codigo");
            DropColumn("dbo.Locacaos", "DatAlt");
            DropColumn("dbo.Locacaos", "DatInc");
            DropColumn("dbo.Locacaos", "UsuAlt");
            DropColumn("dbo.Locacaos", "UsuInc");
            DropColumn("dbo.Locacaos", "Ativo");
            DropColumn("dbo.Locacaos", "Vaga");
            DropColumn("dbo.Cors", "DatAlt");
            DropColumn("dbo.Cors", "DatInc");
            DropColumn("dbo.Cors", "UsuAlt");
            DropColumn("dbo.Cors", "UsuInc");
            DropColumn("dbo.Cors", "Ativo");
            DropTable("dbo.Marcas");
            DropTable("dbo.Modeloes");
            DropTable("dbo.Periodoes");
            CreateIndex("dbo.Motoes", "ModeloMoto_Codigo");
            CreateIndex("dbo.Motoes", "MarcaMoto_Codigo");
            CreateIndex("dbo.TipoVeiculoes", "Patinete_Codigo");
            CreateIndex("dbo.TipoVeiculoes", "Moto_Codigo");
            CreateIndex("dbo.TipoVeiculoes", "Bicicleta_Codigo");
            CreateIndex("dbo.TipoVeiculoes", "Automovel_Codigo");
            CreateIndex("dbo.RegistroVeiculoes", "TipoVeiculo_Id");
            CreateIndex("dbo.Locacaos", "RegistroVeiculo_Codigo");
            CreateIndex("dbo.Automovels", "ModeloAutomovel_Codigo");
            CreateIndex("dbo.Automovels", "MarcaAutomovel_Codigo");
            AddForeignKey("dbo.Locacaos", "RegistroVeiculo_Codigo", "dbo.RegistroVeiculoes", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.RegistroVeiculoes", "TipoVeiculo_Id", "dbo.TipoVeiculoes", "Id");
            AddForeignKey("dbo.TipoVeiculoes", "Patinete_Codigo", "dbo.Patinetes", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.TipoVeiculoes", "Moto_Codigo", "dbo.Motoes", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.Motoes", "ModeloMoto_Codigo", "dbo.ModeloMotoes", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.Motoes", "MarcaMoto_Codigo", "dbo.MarcaMotoes", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.TipoVeiculoes", "Bicicleta_Codigo", "dbo.Bicicletas", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.TipoVeiculoes", "Automovel_Codigo", "dbo.Automovels", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.Automovels", "ModeloAutomovel_Codigo", "dbo.ModeloAutomovels", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.Automovels", "MarcaAutomovel_Codigo", "dbo.MarcaAutomovels", "Codigo", cascadeDelete: true);
        }
    }
}
