namespace CodeFirstApproach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeModels", "age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeModels", "age");
        }
    }
}
