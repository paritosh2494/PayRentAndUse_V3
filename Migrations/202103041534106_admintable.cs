namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admintable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        UserPassword = c.String(nullable: false),
                        UserRePassword = c.String(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminClasses");
        }
    }
}
