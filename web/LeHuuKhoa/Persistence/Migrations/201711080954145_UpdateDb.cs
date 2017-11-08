namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuPages", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.MenuPages", "PageId", "dbo.Pages");
            DropForeignKey("dbo.Posts", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "FileId", "dbo.Files");
            DropIndex("dbo.MenuPages", new[] { "PageId" });
            DropIndex("dbo.MenuPages", new[] { "MenuId" });
            DropIndex("dbo.Posts", new[] { "AuthorId" });
            DropIndex("dbo.Posts", new[] { "FileId" });
            DropPrimaryKey("dbo.Posts");
            AddColumn("dbo.PostCategories", "ShortDescriptions", c => c.String());
            AddColumn("dbo.Menus", "PageId", c => c.String(maxLength: 256));
            AddColumn("dbo.Posts", "Descriptions", c => c.String(nullable: false, maxLength: 1000));
            AddColumn("dbo.Posts", "AuthorName", c => c.String());
            AlterColumn("dbo.Posts", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Posts", "Id");
            CreateIndex("dbo.Menus", "PageId");
            AddForeignKey("dbo.Menus", "PageId", "dbo.Pages", "Id");
            DropColumn("dbo.Posts", "Description");
            DropColumn("dbo.Posts", "AuthorId");
            DropColumn("dbo.Posts", "IsPublished");
            DropColumn("dbo.Posts", "IsDeleted");
            DropColumn("dbo.Posts", "FileId");
            DropColumn("dbo.Posts", "PostType");
            DropTable("dbo.MenuPages");
            DropTable("dbo.Files");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        FileSize = c.String(),
                        FileType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuPages",
                c => new
                    {
                        PageId = c.String(nullable: false, maxLength: 256),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PageId, t.MenuId });
            
            AddColumn("dbo.Posts", "PostType", c => c.Int());
            AddColumn("dbo.Posts", "FileId", c => c.Long(nullable: false));
            AddColumn("dbo.Posts", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "IsPublished", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "AuthorId", c => c.String(maxLength: 128));
            AddColumn("dbo.Posts", "Description", c => c.String(maxLength: 1000));
            DropForeignKey("dbo.Menus", "PageId", "dbo.Pages");
            DropIndex("dbo.Menus", new[] { "PageId" });
            DropPrimaryKey("dbo.Posts");
            AlterColumn("dbo.Posts", "Content", c => c.String());
            AlterColumn("dbo.Posts", "Id", c => c.Long(nullable: false, identity: true));
            DropColumn("dbo.Posts", "AuthorName");
            DropColumn("dbo.Posts", "Descriptions");
            DropColumn("dbo.Menus", "PageId");
            DropColumn("dbo.PostCategories", "ShortDescriptions");
            AddPrimaryKey("dbo.Posts", "Id");
            CreateIndex("dbo.Posts", "FileId");
            CreateIndex("dbo.Posts", "AuthorId");
            CreateIndex("dbo.MenuPages", "MenuId");
            CreateIndex("dbo.MenuPages", "PageId");
            AddForeignKey("dbo.Posts", "FileId", "dbo.Files", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "AuthorId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.MenuPages", "PageId", "dbo.Pages", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MenuPages", "MenuId", "dbo.Menus", "Id", cascadeDelete: true);
        }
    }
}
