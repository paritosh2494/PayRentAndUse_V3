namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userclassupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserClasses", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserClasses", "Gender");
        }
    }
}
