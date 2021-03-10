namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebookingclass : DbMigration
    {
        public override void Up()
        {
            Sql("update bookingclasses set FromBookingDate = '2021-03-31 00:00:00.000' " +
                ", ToBookingDate ='2021-04-02 00:00:00.000',PaymentAmount = 300 ," +
                "PaymentIndicator = 'Y' where Id='1'");
        }
        
        public override void Down()
        {
        }
    }
}
