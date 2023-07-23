namespace FrameWebApiCrud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpID = c.Int(nullable: false, identity: true),
                        EmpName = c.String(),
                        EmpDisg = c.String(),
                        EmpSalary = c.String(),
                    })
                .PrimaryKey(t => t.EmpID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
