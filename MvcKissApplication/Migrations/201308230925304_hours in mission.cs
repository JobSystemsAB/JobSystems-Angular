namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hoursinmission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Missions", "hours", c => c.Int());
            AddColumn("dbo.Missions", "date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Missions", "date");
            DropColumn("dbo.Missions", "hours");
        }
    }
}
