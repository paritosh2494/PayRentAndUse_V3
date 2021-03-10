namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addatatonewcolumn : DbMigration
    {
        public override void Up()
        {
            Sql("Update VendorClasses set AvailableVehicle = VehicleCount");
        }
        
        public override void Down()
        {
        }
    }
}
