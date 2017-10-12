namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePageTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "BackgroundImage", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "BackgroundImage");
        }
    }
}
