namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdmin : DbMigration
    {
        public override void Up()
        {
            Sql("insert into dbo.AdminClasses values ('Admin_Rohit','M','admin_rohit@vrs.com','4/3/2021 1:22:15 PM','admin','admin')");
        }
        
        public override void Down()
        {
        }
    }
}
