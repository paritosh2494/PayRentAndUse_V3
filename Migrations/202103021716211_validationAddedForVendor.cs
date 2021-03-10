namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationAddedForVendor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VendorClasses", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.VendorClasses", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.VendorClasses", "VendorPassword", c => c.String(nullable: false));
            AlterColumn("dbo.VendorClasses", "VendorRePassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VendorClasses", "VendorRePassword", c => c.String());
            AlterColumn("dbo.VendorClasses", "VendorPassword", c => c.String());
            AlterColumn("dbo.VendorClasses", "Email", c => c.String());
            AlterColumn("dbo.VendorClasses", "Name", c => c.String());
        }
    }
}
