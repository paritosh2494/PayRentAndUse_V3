namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userroleupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRoleClasses", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRoleClasses", "DateAdded");
        }
    }
}
