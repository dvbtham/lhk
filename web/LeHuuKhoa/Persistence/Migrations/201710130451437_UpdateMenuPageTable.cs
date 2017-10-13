namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMenuPageTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MenuPages");
            AlterColumn("dbo.MenuPages", "PageId", c => c.String(nullable: false, maxLength: 256));
            AddPrimaryKey("dbo.MenuPages", new[] { "PageId", "MenuId" });
            CreateIndex("dbo.MenuPages", "PageId");
            AddForeignKey("dbo.MenuPages", "PageId", "dbo.Pages", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuPages", "PageId", "dbo.Pages");
            DropIndex("dbo.MenuPages", new[] { "PageId" });
            DropPrimaryKey("dbo.MenuPages");
            AlterColumn("dbo.MenuPages", "PageId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.MenuPages", new[] { "PageId", "MenuId" });
        }
    }
}
