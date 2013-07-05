namespace MvcWebRole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Clienttypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Performers", "profilePictureUrl", c => c.String());
            AddColumn("dbo.Clients", "firstName", c => c.String());
            AddColumn("dbo.Clients", "lastName", c => c.String());
            AddColumn("dbo.Clients", "personalNumber", c => c.String());
            AddColumn("dbo.Clients", "propertyName", c => c.String());
            AddColumn("dbo.Clients", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Clients", "visitAddress");
            DropColumn("dbo.Clients", "contactPersonName");
            DropColumn("dbo.Clients", "contactPersonPhone");
            DropColumn("dbo.Clients", "invoiceEmailAddress");
            DropColumn("dbo.Clients", "invoiceEmailAddressCopy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "invoiceEmailAddressCopy", c => c.String());
            AddColumn("dbo.Clients", "invoiceEmailAddress", c => c.String());
            AddColumn("dbo.Clients", "contactPersonPhone", c => c.String());
            AddColumn("dbo.Clients", "contactPersonName", c => c.String());
            AddColumn("dbo.Clients", "visitAddress", c => c.String());
            DropColumn("dbo.Clients", "Discriminator");
            DropColumn("dbo.Clients", "propertyName");
            DropColumn("dbo.Clients", "personalNumber");
            DropColumn("dbo.Clients", "lastName");
            DropColumn("dbo.Clients", "firstName");
            DropColumn("dbo.Performers", "profilePictureUrl");
        }
    }
}
