namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class text1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Texts", "text", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Texts", "text");
        }
    }
}
