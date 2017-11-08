namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostTypeColunm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "PostType");
        }
    }
}
