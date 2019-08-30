namespace HBSIS.TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBquatro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vagas", "TipoVeiculo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vagas", "TipoVeiculo");
        }
    }
}
