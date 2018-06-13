namespace MLG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PicturePathAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "PicturePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "PicturePath");
        }
    }
}
