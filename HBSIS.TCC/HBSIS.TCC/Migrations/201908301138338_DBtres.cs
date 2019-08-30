namespace HBSIS.TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBtres : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locacaos", "Placa", c => c.String());
            DropColumn("dbo.RegistroVeiculoes", "Placa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegistroVeiculoes", "Placa", c => c.String());
            DropColumn("dbo.Locacaos", "Placa");
        }
    }
}
