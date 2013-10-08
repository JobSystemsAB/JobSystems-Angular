namespace PageAndServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "url");
        }
    }
}
