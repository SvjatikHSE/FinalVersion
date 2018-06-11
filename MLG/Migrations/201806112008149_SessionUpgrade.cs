namespace MLG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SessionUpgrade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        PackName = c.String(),
                        Package_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Package_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Sessions", "Package_Id", "dbo.Packages");
            DropIndex("dbo.Sessions", new[] { "User_Id" });
            DropIndex("dbo.Sessions", new[] { "Package_Id" });
            DropTable("dbo.Sessions");
        }
    }
}
