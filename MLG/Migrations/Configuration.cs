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
            package.LoadData("C:/Users/mir.shn/source/repos/FinalVersionn/Game_UI/TestFile.xml", 1);
            Package package2 = new Package();
            package2.LoadData("C:/Users/mir.shn/source/repos/FinalVersionn/Game_UI/TestFile2.xml", 2);
            Package package3 = new Package();
            package3.LoadData("C:/Users/mir.shn/source/repos/FinalVersionn/Game_UI/TestFile3.xml", 3);
            using (var dbContext = new BDContext())
            {
                dbContext.Packages.AddOrUpdate(x=>x.Name,package);
                dbContext.Packages.AddOrUpdate(x => x.Name, package2);
                dbContext.Packages.AddOrUpdate(x => x.Name, package3);
                dbContext.SaveChanges();
            }
        }
    }
}
