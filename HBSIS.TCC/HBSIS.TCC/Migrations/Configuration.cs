namespace HBSIS.TCC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HBSIS.TCC.Models.ContextDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HBSIS.TCC.Models.ContextDB context)
        {
            //  This method will be called after migrating to the latest version.
            // var listRodas = new List<Roda>()
            // {
            //      new Roda() { Descricao = "Rebaxei aro 16" }, 
            //      new Roda() { Descricao = "Rebaxei aro 20" }
            //  }
            //
            //  list.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
