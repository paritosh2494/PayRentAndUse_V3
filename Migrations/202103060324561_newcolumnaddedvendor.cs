namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcolumnaddedvendor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VendorClasses", "BookedVehicle", c => c.Int(nullable: false));
            AddColumn("dbo.VendorClasses", "AvailableVehicle", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VendorClasses", "AvailableVehicle");
            DropColumn("dbo.VendorClasses", "BookedVehicle");
        }
    }
}
