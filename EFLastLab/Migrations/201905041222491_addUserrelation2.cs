namespace EFLastLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserrelation2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserCities", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserCities", "City_Id", "dbo.Cities");
            DropIndex("dbo.UserCities", new[] { "User_Id" });
            DropIndex("dbo.UserCities", new[] { "City_Id" });
            CreateTable(
                "dbo.UserVisits",
                c => new
                    {
                        CityId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        When = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CityId, t.UserId })
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.UserId);
            
            DropTable("dbo.UserCities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserCities",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        City_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.City_Id });
            
            DropForeignKey("dbo.UserVisits", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserVisits", "CityId", "dbo.Cities");
            DropIndex("dbo.UserVisits", new[] { "UserId" });
            DropIndex("dbo.UserVisits", new[] { "CityId" });
            DropTable("dbo.UserVisits");
            CreateIndex("dbo.UserCities", "City_Id");
            CreateIndex("dbo.UserCities", "User_Id");
            AddForeignKey("dbo.UserCities", "City_Id", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserCities", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
