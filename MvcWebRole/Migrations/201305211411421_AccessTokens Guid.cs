namespace MvcWebRole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccessTokensGuid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TimeReports", "assignmentId", "dbo.Assignments");
            DropForeignKey("dbo.TimeReports", "performerId", "dbo.Performers");
            DropIndex("dbo.TimeReports", new[] { "assignmentId" });
            DropIndex("dbo.TimeReports", new[] { "performerId" });
            CreateTable(
                "dbo.PerformerAccessTokens",
                c => new
                    {
                        id = c.Int(nullable: false),
                        performerId = c.Int(),
                        accessToken = c.Guid(nullable: false),
                        created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Performers", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.AdministratorAccessTokens",
                c => new
                    {
                        id = c.Int(nullable: false),
                        administratorId = c.Int(),
                        accessToken = c.Guid(nullable: false),
                        created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Administrators", t => t.id)
                .Index(t => t.id);
            
            AddColumn("dbo.Performers", "accessTokenId", c => c.Int());
            AddColumn("dbo.Administrators", "accessTokenId", c => c.Int());
            AlterColumn("dbo.TimeReports", "assignmentId", c => c.Int());
            AlterColumn("dbo.TimeReports", "performerId", c => c.Int());
            AddForeignKey("dbo.TimeReports", "assignmentId", "dbo.Assignments", "id");
            AddForeignKey("dbo.TimeReports", "performerId", "dbo.Performers", "id");
            CreateIndex("dbo.TimeReports", "assignmentId");
            CreateIndex("dbo.TimeReports", "performerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AdministratorAccessTokens", new[] { "id" });
            DropIndex("dbo.TimeReports", new[] { "performerId" });
            DropIndex("dbo.TimeReports", new[] { "assignmentId" });
            DropIndex("dbo.PerformerAccessTokens", new[] { "id" });
            DropForeignKey("dbo.AdministratorAccessTokens", "id", "dbo.Administrators");
            DropForeignKey("dbo.TimeReports", "performerId", "dbo.Performers");
            DropForeignKey("dbo.TimeReports", "assignmentId", "dbo.Assignments");
            DropForeignKey("dbo.PerformerAccessTokens", "id", "dbo.Performers");
            AlterColumn("dbo.TimeReports", "performerId", c => c.Int(nullable: false));
            AlterColumn("dbo.TimeReports", "assignmentId", c => c.Int(nullable: false));
            DropColumn("dbo.Administrators", "accessTokenId");
            DropColumn("dbo.Performers", "accessTokenId");
            DropTable("dbo.AdministratorAccessTokens");
            DropTable("dbo.PerformerAccessTokens");
            CreateIndex("dbo.TimeReports", "performerId");
            CreateIndex("dbo.TimeReports", "assignmentId");
            AddForeignKey("dbo.TimeReports", "performerId", "dbo.Performers", "id", cascadeDelete: true);
            AddForeignKey("dbo.TimeReports", "assignmentId", "dbo.Assignments", "id", cascadeDelete: true);
        }
    }
}
