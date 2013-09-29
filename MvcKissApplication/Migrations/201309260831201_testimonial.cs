namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testimonial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Testimonials", "language", c => c.String());
            DropColumn("dbo.Testimonials", "updated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Testimonials", "updated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Testimonials", "language");
        }
    }
}
