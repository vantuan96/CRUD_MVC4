namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Student", "Student_Id", "dbo.Student");
            DropIndex("dbo.Student", new[] { "Student_Id" });
            DropColumn("dbo.Student", "Student_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "Student_Id", c => c.Int());
            CreateIndex("dbo.Student", "Student_Id");
            AddForeignKey("dbo.Student", "Student_Id", "dbo.Student", "Id");
        }
    }
}
