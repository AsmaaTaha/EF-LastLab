namespace EFLastLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddemployee1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Departments", newName: "Department");
            RenameTable(name: "dbo.Employees", newName: "Employee");
            DropIndex("dbo.Employee", new[] { "department_Id" });
            RenameColumn(table: "dbo.Employee", name: "department_Id", newName: "Fk_Department");
            AlterColumn("dbo.Department", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employee", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employee", "Fk_Department", c => c.Int(nullable: false));
            CreateIndex("dbo.Employee", "Fk_Department");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employee", new[] { "Fk_Department" });
            AlterColumn("dbo.Employee", "Fk_Department", c => c.Int());
            AlterColumn("dbo.Employee", "Name", c => c.String());
            AlterColumn("dbo.Department", "Name", c => c.String());
            RenameColumn(table: "dbo.Employee", name: "Fk_Department", newName: "department_Id");
            CreateIndex("dbo.Employee", "department_Id");
            RenameTable(name: "dbo.Employee", newName: "Employees");
            RenameTable(name: "dbo.Department", newName: "Departments");
        }
    }
}
