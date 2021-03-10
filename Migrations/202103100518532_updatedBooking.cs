namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedBooking : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FeedbackClasses", "Rating", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FeedbackClasses", "Rating", c => c.String());
        }
    }
}
