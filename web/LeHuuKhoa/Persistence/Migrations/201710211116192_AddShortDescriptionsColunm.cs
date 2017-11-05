namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShortDescriptionsColunm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostCategories", "ShortDescriptions", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostCategories", "ShortDescriptions");
        }
    }
}
