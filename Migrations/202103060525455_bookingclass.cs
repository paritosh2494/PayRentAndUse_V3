namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookingclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingClasses", "FromBookingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BookingClasses", "ToBookingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BookingClasses", "PaymentAmount", c => c.Int(nullable: false));
            AddColumn("dbo.BookingClasses", "PaymentIndicator", c => c.String());
            DropColumn("dbo.BookingClasses", "BookingDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingClasses", "BookingDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.BookingClasses", "PaymentIndicator");
            DropColumn("dbo.BookingClasses", "PaymentAmount");
            DropColumn("dbo.BookingClasses", "ToBookingDate");
            DropColumn("dbo.BookingClasses", "FromBookingDate");
        }
    }
}
