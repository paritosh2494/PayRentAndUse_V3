namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedbackadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedbackClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserClassId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        FeedBack = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserClasses", t => t.UserClassId, cascadeDelete: true)
                .Index(t => t.UserClassId);
            
            AddColumn("dbo.UserClasses", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.UserClasses", "Feedback", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeedbackClasses", "UserClassId", "dbo.UserClasses");
            DropIndex("dbo.FeedbackClasses", new[] { "UserClassId" });
            DropColumn("dbo.UserClasses", "Feedback");
            DropColumn("dbo.UserClasses", "Rating");
            DropTable("dbo.FeedbackClasses");
        }
    }
}
