namespace EFLastLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcoverbookrelation : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Covers");
            AlterColumn("dbo.Covers", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Covers", "Id");
            CreateIndex("dbo.Covers", "Id");
            AddForeignKey("dbo.Covers", "Id", "dbo.Books", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Covers", "Id", "dbo.Books");
            DropIndex("dbo.Covers", new[] { "Id" });
            DropPrimaryKey("dbo.Covers");
            AlterColumn("dbo.Covers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Covers", "Id");
        }
    }
}
