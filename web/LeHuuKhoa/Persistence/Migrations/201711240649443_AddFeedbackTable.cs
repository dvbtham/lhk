namespace LeHuuKhoa.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFeedbackTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 256),
                        Email = c.String(nullable: false, maxLength: 256),
                        Phone = c.String(maxLength: 100),
                        Website = c.String(maxLength: 500),
                        Address = c.String(maxLength: 500),
                        Country = c.String(maxLength: 500),
                        Message = c.String(nullable: false, maxLength: 1500),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Feedbacks");
        }
    }
}
