using System.Data.Entity.Migrations;

namespace LeHuuKhoa.Persistence.Migrations
{
    public partial class UpdateNewDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleAttributes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleGroupArticleAttributes",
                c => new
                    {
                        ArticleAttributeId = c.Long(nullable: false),
                        ArticleGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleAttributeId, t.ArticleGroupId })
                .ForeignKey("dbo.ArticleAttributes", t => t.ArticleAttributeId, cascadeDelete: true)
                .ForeignKey("dbo.ArticleGroups", t => t.ArticleGroupId, cascadeDelete: true)
                .Index(t => t.ArticleAttributeId)
                .Index(t => t.ArticleGroupId);
            
            CreateTable(
                "dbo.ArticleGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleAttributeValues",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AttributeId = c.Long(nullable: false),
                        ArticleId = c.Long(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.ArticleAttributes", t => t.AttributeId, cascadeDelete: true)
                .Index(t => t.AttributeId)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Slug = c.String(nullable: false, maxLength: 100),
                        Descriptions = c.String(nullable: false, maxLength: 1000),
                        BackgroundImage = c.String(),
                        Content = c.String(nullable: false),
                        CategoryId = c.String(nullable: false, maxLength: 100),
                        Views = c.Int(nullable: false),
                        IsPopularPost = c.Boolean(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateUpdated = c.DateTime(precision: 7, storeType: "datetime2"),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                        Author_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        ImageUrl = c.String(nullable: false, maxLength: 256),
                        Birthday = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 20),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 100),
                        Slug = c.String(),
                        Avatar = c.String(nullable: false, maxLength: 256),
                        DisplayOrder = c.Byte(nullable: false),
                        Descriptions = c.String(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ArticleGroup_Id = c.Int(),
                        File_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleGroups", t => t.ArticleGroup_Id)
                .ForeignKey("dbo.Files", t => t.File_Id)
                .Index(t => t.ArticleGroup_Id)
                .Index(t => t.File_Id);
            
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
                "dbo.ArticleFiles",
                c => new
                    {
                        ArticleId = c.Long(nullable: false),
                        FileId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleId, t.FileId })
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Files", t => t.FileId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.FileId);
            
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
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 256),
                        Name = c.String(nullable: false, maxLength: 256),
                        BackgroundImage = c.String(maxLength: 256),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Menus", "PageId", "dbo.Pages");
            DropForeignKey("dbo.ArticleFiles", "FileId", "dbo.Files");
            DropForeignKey("dbo.ArticleFiles", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.ArticleAttributeValues", "AttributeId", "dbo.ArticleAttributes");
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "File_Id", "dbo.Files");
            DropForeignKey("dbo.Categories", "ArticleGroup_Id", "dbo.ArticleGroups");
            DropForeignKey("dbo.Articles", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ArticleAttributeValues", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.ArticleGroupArticleAttributes", "ArticleGroupId", "dbo.ArticleGroups");
            DropForeignKey("dbo.ArticleGroupArticleAttributes", "ArticleAttributeId", "dbo.ArticleAttributes");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Menus", new[] { "PageId" });
            DropIndex("dbo.ArticleFiles", new[] { "FileId" });
            DropIndex("dbo.ArticleFiles", new[] { "ArticleId" });
            DropIndex("dbo.Categories", new[] { "File_Id" });
            DropIndex("dbo.Categories", new[] { "ArticleGroup_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Articles", new[] { "Author_Id" });
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            DropIndex("dbo.ArticleAttributeValues", new[] { "ArticleId" });
            DropIndex("dbo.ArticleAttributeValues", new[] { "AttributeId" });
            DropIndex("dbo.ArticleGroupArticleAttributes", new[] { "ArticleGroupId" });
            DropIndex("dbo.ArticleGroupArticleAttributes", new[] { "ArticleAttributeId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Pages");
            DropTable("dbo.Menus");
            DropTable("dbo.ArticleFiles");
            DropTable("dbo.Files");
            DropTable("dbo.Categories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Articles");
            DropTable("dbo.ArticleAttributeValues");
            DropTable("dbo.ArticleGroups");
            DropTable("dbo.ArticleGroupArticleAttributes");
            DropTable("dbo.ArticleAttributes");
        }
    }
}
