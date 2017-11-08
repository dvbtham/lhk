namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePageTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "PinToHome", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "PinToHome");
        }
    }
}
