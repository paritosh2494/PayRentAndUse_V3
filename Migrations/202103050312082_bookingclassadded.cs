namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookingclassadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserClassId = c.Int(nullable: false),
                        VendorClassId = c.Int(nullable: false),
                        VehicleClassId = c.Int(nullable: false),
                        RequiredVehicle = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserClasses", t => t.UserClassId, cascadeDelete: false)
                .ForeignKey("dbo.VehicleClasses", t => t.VehicleClassId, cascadeDelete: false)
                .ForeignKey("dbo.VendorClasses", t => t.VendorClassId, cascadeDelete: false)
                .Index(t => t.UserClassId)
                .Index(t => t.VendorClassId)
                .Index(t => t.VehicleClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingClasses", "VendorClassId", "dbo.VendorClasses");
            DropForeignKey("dbo.BookingClasses", "VehicleClassId", "dbo.VehicleClasses");
            DropForeignKey("dbo.BookingClasses", "UserClassId", "dbo.UserClasses");
            DropIndex("dbo.BookingClasses", new[] { "VehicleClassId" });
            DropIndex("dbo.BookingClasses", new[] { "VendorClassId" });
            DropIndex("dbo.BookingClasses", new[] { "UserClassId" });
            DropTable("dbo.BookingClasses");
        }
    }
}
