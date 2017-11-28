namespace PT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ActivationCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ActivationCode");
        }
    }
}
