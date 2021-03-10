namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserClassDatetimeadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserClasses", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserClasses", "DateAdded");
        }
    }
}
