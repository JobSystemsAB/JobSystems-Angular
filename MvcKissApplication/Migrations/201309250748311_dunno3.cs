namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dunno3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        testimonial_id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        name = c.String(),
                        created = c.DateTime(nullable: false),
                        updated = c.DateTime(nullable: false),
                        enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.testimonial_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Testimonials");
        }
    }
}
