namespace _05_03_TransactionScope.FlightDbContextMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlightBookings",
                c => new
                    {
                        FlightID = c.Int(nullable: false, identity: true),
                        FlightName = c.String(),
                        Number = c.String(),
                        TravellingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FlightID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FlightBookings");
        }
    }
}
