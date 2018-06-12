namespace MLG.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MLG.BDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MLG.BDContext";
        }

        protected override void Seed(MLG.BDContext context)
        {
            Package package = new Package();
            package.LoadData("C:/Users/Анастасия/source/repos/FinalVersion/Game_UI/TestFile.xml");
            using (var dbContext = new BDContext())
            {
                dbContext.Packages.AddOrUpdate(x => x.Name, package);
                dbContext.SaveChanges();
            }
        }
    }
}
