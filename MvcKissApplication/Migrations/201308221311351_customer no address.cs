namespace MvcKissApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customernoaddress : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "address_streetNumber");
            DropColumn("dbo.Customers", "address_street");
            DropColumn("dbo.Customers", "address_postalCode");
            DropColumn("dbo.Customers", "address_postalTown");
            DropColumn("dbo.Customers", "address_country");
            DropColumn("dbo.Customers", "address_longitude");
            DropColumn("dbo.Customers", "address_latitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "address_latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Customers", "address_longitude", c => c.Double(nullable: false));
            AddColumn("dbo.Customers", "address_country", c => c.String());
            AddColumn("dbo.Customers", "address_postalTown", c => c.String());
            AddColumn("dbo.Customers", "address_postalCode", c => c.String());
            AddColumn("dbo.Customers", "address_street", c => c.String());
            AddColumn("dbo.Customers", "address_streetNumber", c => c.String());
        }
    }
}
