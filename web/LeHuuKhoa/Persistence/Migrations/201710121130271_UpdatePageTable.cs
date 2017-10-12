namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePageTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Pages", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pages", "Content", c => c.String());
            DropColumn("dbo.Pages", "Name");
        }
    }
}
