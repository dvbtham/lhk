namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagesColunmToPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Images", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Images");
        }
    }
}
