namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDateUpdatedNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "DateUpdated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "DateUpdated", c => c.DateTime(nullable: false));
        }
    }
}
