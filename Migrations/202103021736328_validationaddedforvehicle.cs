namespace PayRentAndUse_V3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationaddedforvehicle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleClasses", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleClasses", "Name", c => c.String());
        }
    }
}
