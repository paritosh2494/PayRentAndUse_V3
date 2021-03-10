namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vendorfieldupdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VendorClasses", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VendorClasses", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
