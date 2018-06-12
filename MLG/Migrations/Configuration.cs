namespace MLG.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<MLG.BDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MLG.BDContext";
        }

        private string MapPath(string seedFile)
        {

            var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath; //was AbsolutePath but didn't work with spaces according to comments
            var directoryName = Path.GetDirectoryName(absolutePath);
            var path = Path.Combine(directoryName,seedFile.TrimStart('~').Replace('/', '\\'));
            path = path.Replace("MLG\\MLG", "MLG\\Game_UI");

            return path;
        }

        protected override void Seed(MLG.BDContext context)
        {

            Package package = new Package();
            package.LoadData(MapPath("TestFile.xml"));
            Package package2 = new Package();
            package2.LoadData(MapPath("TestFile2.xml"));
            Package package3 = new Package();
            package3.LoadData(MapPath("TestFile3.xml"));
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
