namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propnameupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdminClasses", "AdminPassword", c => c.String(nullable: false));
            AddColumn("dbo.AdminClasses", "AdminRePassword", c => c.String(nullable: false));
            DropColumn("dbo.AdminClasses", "UserPassword");
            DropColumn("dbo.AdminClasses", "UserRePassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdminClasses", "UserRePassword", c => c.String(nullable: false));
            AddColumn("dbo.AdminClasses", "UserPassword", c => c.String(nullable: false));
            DropColumn("dbo.AdminClasses", "AdminRePassword");
            DropColumn("dbo.AdminClasses", "AdminPassword");
        }
    }
}
