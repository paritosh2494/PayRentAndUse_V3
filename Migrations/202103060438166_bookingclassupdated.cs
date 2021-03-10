namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookingclassupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingClasses", "BookingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BookingClasses", "BookedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingClasses", "BookedDate");
            DropColumn("dbo.BookingClasses", "BookingDate");
        }
    }
}
