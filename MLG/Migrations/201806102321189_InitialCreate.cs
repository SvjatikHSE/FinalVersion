namespace MLG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsAlreadyPlayed = c.Boolean(nullable: false),
                        ResultOfUser = c.Int(),
                        CurrentQuestion_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.CurrentQuestion_Id)
                .Index(t => t.CurrentQuestion_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Points = c.Int(nullable: false),
                        TourFileName = c.String(),
                        FieldQuestion = c.String(),
                        Answer = c.String(),
                        Author = c.String(),
                        Comments = c.String(),
                        TourTittle = c.String(),
                        TournamentTittle = c.String(),
                        Package_Id = c.Int(),
                        Package_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id1)
                .Index(t => t.Package_Id)
                .Index(t => t.Package_Id1);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Answer = c.String(),
                        SessionRating = c.Int(nullable: false),
                        TotalRating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Package_Id1", "dbo.Packages");
            DropForeignKey("dbo.Questions", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.Packages", "CurrentQuestion_Id", "dbo.Questions");
            DropIndex("dbo.Questions", new[] { "Package_Id1" });
            DropIndex("dbo.Questions", new[] { "Package_Id" });
            DropIndex("dbo.Packages", new[] { "CurrentQuestion_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Questions");
            DropTable("dbo.Packages");
        }
    }
}
