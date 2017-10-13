namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMenuTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PageId = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pages", t => t.PageId)
                .Index(t => t.PageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "PageId", "dbo.Pages");
            DropIndex("dbo.Menus", new[] { "PageId" });
            DropTable("dbo.Menus");
        }
    }
}
