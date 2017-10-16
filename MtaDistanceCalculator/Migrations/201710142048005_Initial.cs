namespace MtaDistanceCalculator.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StopId = c.String(nullable: false),
                        StopName = c.String(nullable: false),
                        StopLatitude = c.Double(nullable: false),
                        StopLongitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stations");
        }
    }
}
