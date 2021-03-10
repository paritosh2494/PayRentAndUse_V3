namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataypeupdatedFeedback : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FeedbackClasses", "Rating", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FeedbackClasses", "Rating", c => c.Int(nullable: false));
        }
    }
}
