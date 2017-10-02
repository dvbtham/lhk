namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateTimeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Posts", "DateUpdated", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "DateUpdated", c => c.DateTime());
            AlterColumn("dbo.Posts", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
