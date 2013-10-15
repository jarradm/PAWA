namespace PAWA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDailyStatisticsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyStatistics",
                c => new
                    {
                        DailyStatisticsID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        UsersAddedCount = c.Int(),
                        UsersLostCount = c.Int(),
                        ImagesAddedCount = c.Int(),
                        ImagesLostCount = c.Int(),
                        VideosAddedCount = c.Int(),
                        VideosLostCount = c.Int(),
                    })
                .PrimaryKey(t => t.DailyStatisticsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DailyStatistics");
        }
    }
}
