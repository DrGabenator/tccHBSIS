namespace HBSIS.TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBdois : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vagas", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Locacaos", "Valor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locacaos", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Vagas", "Valor");
        }
    }
}
