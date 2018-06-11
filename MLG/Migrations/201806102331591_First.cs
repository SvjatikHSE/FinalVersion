namespace MLG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Package_Id1", "dbo.Packages");
            DropIndex("dbo.Questions", new[] { "Package_Id1" });
            DropColumn("dbo.Questions", "Package_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Package_Id1", c => c.Int());
            CreateIndex("dbo.Questions", "Package_Id1");
            AddForeignKey("dbo.Questions", "Package_Id1", "dbo.Packages", "Id");
        }
    }
}
