namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMenuToPageRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuPages", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.MenuPages", "PageId", "dbo.Pages");
            DropIndex("dbo.MenuPages", new[] { "PageId" });
            DropIndex("dbo.MenuPages", new[] { "MenuId" });
            AddColumn("dbo.Menus", "PageId", c => c.String(maxLength: 256));
            CreateIndex("dbo.Menus", "PageId");
            AddForeignKey("dbo.Menus", "PageId", "dbo.Pages", "Id");
            DropTable("dbo.MenuPages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MenuPages",
                c => new
                    {
                        PageId = c.String(nullable: false, maxLength: 256),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PageId, t.MenuId });
            
            DropForeignKey("dbo.Menus", "PageId", "dbo.Pages");
            DropIndex("dbo.Menus", new[] { "PageId" });
            DropColumn("dbo.Menus", "PageId");
            CreateIndex("dbo.MenuPages", "MenuId");
            CreateIndex("dbo.MenuPages", "PageId");
            AddForeignKey("dbo.MenuPages", "PageId", "dbo.Pages", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MenuPages", "MenuId", "dbo.Menus", "Id", cascadeDelete: true);
        }
    }
}
