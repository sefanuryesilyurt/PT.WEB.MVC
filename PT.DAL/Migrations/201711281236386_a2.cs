namespace PT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "DepartmanId", "dbo.Departmens");
            DropIndex("dbo.AspNetUsers", new[] { "DepartmanId" });
            AlterColumn("dbo.AspNetUsers", "DepartmanId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "DepartmanId");
            AddForeignKey("dbo.AspNetUsers", "DepartmanId", "dbo.Departmens", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "DepartmanId", "dbo.Departmens");
            DropIndex("dbo.AspNetUsers", new[] { "DepartmanId" });
            AlterColumn("dbo.AspNetUsers", "DepartmanId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "DepartmanId");
            AddForeignKey("dbo.AspNetUsers", "DepartmanId", "dbo.Departmens", "Id", cascadeDelete: true);
        }
    }
}
