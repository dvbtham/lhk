namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFileTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Files", "FileSize", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Files", "FileSize", c => c.String());
        }
    }
}
