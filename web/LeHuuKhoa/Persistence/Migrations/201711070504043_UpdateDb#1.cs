namespace LeHuuKhoa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDb1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ArticleGroups", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Articles", "Descriptions", c => c.String());
            DropColumn("dbo.Articles", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "Descriptions", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.ArticleGroups", "Name", c => c.Int(nullable: false));
        }
    }
}
