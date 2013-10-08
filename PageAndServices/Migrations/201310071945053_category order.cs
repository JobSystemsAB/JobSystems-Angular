namespace PageAndServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "order");
        }
    }
}
