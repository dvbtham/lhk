namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMenuTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "PageId", "dbo.Pages");
            DropIndex("dbo.Menus", new[] { "PageId" });
            CreateTable(
                "dbo.MenuPages",
                c => new
                    {
                        PageId = c.String(nullable: false, maxLength: 128),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PageId, t.MenuId })
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
            DropColumn("dbo.Menus", "PageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "PageId", c => c.String(maxLength: 256));
            DropForeignKey("dbo.MenuPages", "MenuId", "dbo.Menus");
            DropIndex("dbo.MenuPages", new[] { "MenuId" });
            DropTable("dbo.MenuPages");
            CreateIndex("dbo.Menus", "PageId");
            AddForeignKey("dbo.Menus", "PageId", "dbo.Pages", "Id");
        }
    }
}
