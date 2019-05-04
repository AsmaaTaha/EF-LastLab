namespace EFLastLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpersonandhomerelation3 : DbMigration
    {
        public override void Up()
        {
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
            
        }
    }
}
