namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserClassValidationAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserClasses", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserClasses", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.UserClasses", "UserPassword", c => c.String(nullable: false));
            AlterColumn("dbo.UserClasses", "UserRePassword", c => c.String(nullable: false));
            DropColumn("dbo.UserClasses", "DateAdded");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserClasses", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserClasses", "UserRePassword", c => c.String());
            AlterColumn("dbo.UserClasses", "UserPassword", c => c.String());
            AlterColumn("dbo.UserClasses", "Email", c => c.String());
            AlterColumn("dbo.UserClasses", "Name", c => c.String());
        }
    }
}
