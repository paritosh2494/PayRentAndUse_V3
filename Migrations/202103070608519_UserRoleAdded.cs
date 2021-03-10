namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRoleAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoleClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        UserType = c.String(),
                        UserRole = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserRoleClasses");
        }
    }
}
