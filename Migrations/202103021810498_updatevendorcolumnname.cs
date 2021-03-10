namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatevendorcolumnname : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.VendorClasses", name: "VehicleId", newName: "VehicleClassId");
            RenameIndex(table: "dbo.VendorClasses", name: "IX_VehicleId", newName: "IX_VehicleClassId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.VendorClasses", name: "IX_VehicleClassId", newName: "IX_VehicleId");
            RenameColumn(table: "dbo.VendorClasses", name: "VehicleClassId", newName: "VehicleId");
        }
    }
}
