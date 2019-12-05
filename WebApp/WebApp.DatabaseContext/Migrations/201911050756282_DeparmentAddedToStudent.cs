namespace WebApp.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeparmentAddedToStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Department", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Department");
        }
    }
}
