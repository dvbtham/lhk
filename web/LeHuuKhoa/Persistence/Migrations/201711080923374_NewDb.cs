namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "File_Id", "dbo.Files");
            DropIndex("dbo.Posts", new[] { "AuthorId" });
            DropIndex("dbo.Posts", new[] { "File_Id" });
            RenameColumn(table: "dbo.Posts", name: "File_Id", newName: "FileId");
            AddColumn("dbo.Files", "Name", c => c.String());
            AlterColumn("dbo.Posts", "Description", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "AuthorId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Posts", "FileId", c => c.Long(nullable: false));
            AlterColumn("dbo.Files", "FileSize", c => c.String());
            CreateIndex("dbo.Posts", "AuthorId");
            CreateIndex("dbo.Posts", "FileId");
            AddForeignKey("dbo.Posts", "AuthorId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Posts", "FileId", "dbo.Files", "Id", cascadeDelete: true);
            DropColumn("dbo.Posts", "PostType");
            DropColumn("dbo.Files", "FileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Files", "FileName", c => c.String());
            AddColumn("dbo.Posts", "PostType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Posts", "FileId", "dbo.Files");
            DropForeignKey("dbo.Posts", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "FileId" });
            DropIndex("dbo.Posts", new[] { "AuthorId" });
            AlterColumn("dbo.Files", "FileSize", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "FileId", c => c.Long());
            AlterColumn("dbo.Posts", "AuthorId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Posts", "Content", c => c.String());
            AlterColumn("dbo.Posts", "Description", c => c.String(maxLength: 1000));
            DropColumn("dbo.Files", "Name");
            RenameColumn(table: "dbo.Posts", name: "FileId", newName: "File_Id");
            CreateIndex("dbo.Posts", "File_Id");
            CreateIndex("dbo.Posts", "AuthorId");
            AddForeignKey("dbo.Posts", "File_Id", "dbo.Files", "Id");
            AddForeignKey("dbo.Posts", "AuthorId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
