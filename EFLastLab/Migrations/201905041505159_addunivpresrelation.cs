namespace EFLastLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addunivpresrelation : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Presidents");
            AlterColumn("dbo.Presidents", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Presidents", "Id");
            CreateIndex("dbo.Presidents", "Id");
            AddForeignKey("dbo.Presidents", "Id", "dbo.Universities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Presidents", "Id", "dbo.Universities");
            DropIndex("dbo.Presidents", new[] { "Id" });
            DropPrimaryKey("dbo.Presidents");
            AlterColumn("dbo.Presidents", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Presidents", "Id");
        }
    }
}
