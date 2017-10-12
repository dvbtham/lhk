namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategoryTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostCategories", "BackgroundImage", c => c.String());
            AlterColumn("dbo.PostCategories", "Descriptions", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PostCategories", "Descriptions", c => c.String(nullable: false, maxLength: 700));
            DropColumn("dbo.PostCategories", "BackgroundImage");
        }
    }
}
