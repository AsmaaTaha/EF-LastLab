namespace EFLastLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddemployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.department_Id)
                .Index(t => t.department_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "department_Id", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "department_Id" });
            DropTable("dbo.Employees");
        }
    }
}
