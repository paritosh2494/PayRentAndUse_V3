namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUserRecord : DbMigration
    {
        public override void Up()
        {
            Sql("update dbo.UserClasses set Gender='M'");
        }
        
        public override void Down()
        {
        }
    }
}
