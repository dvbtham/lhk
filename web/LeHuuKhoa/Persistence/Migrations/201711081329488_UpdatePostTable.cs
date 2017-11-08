namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePostTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Description", c => c.String(maxLength: 1000));
        }
    }
}
