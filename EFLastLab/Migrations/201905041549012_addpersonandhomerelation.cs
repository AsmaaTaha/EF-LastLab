namespace EFLastLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpersonandhomerelation : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.People", newName: "Person");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Person", newName: "People");
        }
    }
}
