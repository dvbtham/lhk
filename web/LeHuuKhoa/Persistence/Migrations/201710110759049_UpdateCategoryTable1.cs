namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategoryTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PostCategories", "BackgroundImage", c => c.String(nullable: true, maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PostCategories", "BackgroundImage", c => c.String());
        }
    }
}
