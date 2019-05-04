namespace EFLastLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpersonandhomerelation5 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Homes");
            AlterColumn("dbo.Homes", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Homes", "Id");
            CreateIndex("dbo.Homes", "Id");
            AddForeignKey("dbo.Homes", "Id", "dbo.Users", "Id");
            DropTable("dbo.Person");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Homes", "Id", "dbo.Users");
            DropIndex("dbo.Homes", new[] { "Id" });
            DropPrimaryKey("dbo.Homes");
            AlterColumn("dbo.Homes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Homes", "Id");
        }
    }
}
