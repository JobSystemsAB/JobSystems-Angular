namespace MvcWebRole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignmentClientTimeReport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        clientId = c.Int(),
                        created = c.DateTime(),
                        updated = c.DateTime(),
                        enabled = c.Boolean(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Clients", t => t.clientId)
                .Index(t => t.clientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        organisationNumber = c.String(),
                        companyName = c.String(),
                        streetAddress = c.String(),
                        streetAddress2 = c.String(),
                        postalCode = c.String(),
                        postTown = c.String(),
                        country = c.String(),
                        visitAddress = c.String(),
                        contactPersonName = c.String(),
                        contactPersonPhone = c.String(),
                        emailAddress = c.String(),
                        phoneNumber = c.String(),
                        SNI = c.String(),
                        invoiceEmailAddress = c.String(),
                        invoiceEmailAddressCopy = c.String(),
                        password = c.String(),
                        created = c.DateTime(),
                        updated = c.DateTime(),
                        enabled = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TimeReports",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        assignmentId = c.Int(nullable: false),
                        performerId = c.Int(nullable: false),
                        hours = c.Int(nullable: false),
                        minutes = c.Int(nullable: false),
                        updated = c.DateTime(),
                        created = c.DateTime(),
                        startReport = c.DateTime(),
                        endReport = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Assignments", t => t.assignmentId, cascadeDelete: true)
                .ForeignKey("dbo.Performers", t => t.performerId, cascadeDelete: true)
                .Index(t => t.assignmentId)
                .Index(t => t.performerId);
            
            CreateTable(
                "dbo.AssignmentPerformers",
                c => new
                    {
                        Assignment_id = c.Int(nullable: false),
                        Performer_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Assignment_id, t.Performer_id })
                .ForeignKey("dbo.Assignments", t => t.Assignment_id, cascadeDelete: true)
                .ForeignKey("dbo.Performers", t => t.Performer_id, cascadeDelete: true)
                .Index(t => t.Assignment_id)
                .Index(t => t.Performer_id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.AssignmentPerformers", new[] { "Performer_id" });
            DropIndex("dbo.AssignmentPerformers", new[] { "Assignment_id" });
            DropIndex("dbo.TimeReports", new[] { "performerId" });
            DropIndex("dbo.TimeReports", new[] { "assignmentId" });
            DropIndex("dbo.Assignments", new[] { "clientId" });
            DropForeignKey("dbo.AssignmentPerformers", "Performer_id", "dbo.Performers");
            DropForeignKey("dbo.AssignmentPerformers", "Assignment_id", "dbo.Assignments");
            DropForeignKey("dbo.TimeReports", "performerId", "dbo.Performers");
            DropForeignKey("dbo.TimeReports", "assignmentId", "dbo.Assignments");
            DropForeignKey("dbo.Assignments", "clientId", "dbo.Clients");
            DropTable("dbo.AssignmentPerformers");
            DropTable("dbo.TimeReports");
            DropTable("dbo.Clients");
            DropTable("dbo.Assignments");
        }
    }
}
