namespace LeHuuKhoa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIdKey1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "PageId", "dbo.Pages");
            DropPrimaryKey("dbo.Pages");
            AlterColumn("dbo.Pages", "Id", c => c.String(nullable: false, maxLength: 256));
            AddPrimaryKey("dbo.Pages", "Id");
            AddForeignKey("dbo.Menus", "PageId", "dbo.Pages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "PageId", "dbo.Pages");
            DropPrimaryKey("dbo.Pages");
            AlterColumn("dbo.Pages", "Id", c => c.String(nullable: false, maxLength: 256));
            AddPrimaryKey("dbo.Pages", "Id");
            AddForeignKey("dbo.Menus", "PageId", "dbo.Pages", "Id");
        }
    }
}
