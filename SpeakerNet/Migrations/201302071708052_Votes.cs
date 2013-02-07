namespace SpeakerNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Votes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Votes",
                c => new {
                    SessionId = c.Int(nullable: false),
                    WebUserId = c.Int(nullable: false),
                    Points = c.Int(nullable: false),
                })
                .PrimaryKey(t => new {t.SessionId, t.WebUserId})
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .ForeignKey("dbo.WebUsers", t => t.WebUserId, cascadeDelete: true)
                .Index(t => t.SessionId)
                .Index(t => t.WebUserId);

            CreateTable(
                "dbo.WebUsers",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 64),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name);
        }

        public override void Down()
        {
            DropIndex("dbo.Votes", new[] {"WebUserId"});
            DropIndex("dbo.Votes", new[] {"SessionId"});
            DropForeignKey("dbo.Votes", "WebUserId", "dbo.WebUsers");
            DropForeignKey("dbo.Votes", "SessionId", "dbo.Sessions");
            DropIndex("dbo.WebUsers", new[] {"Name"});
            DropTable("dbo.WebUsers");
            DropTable("dbo.Votes");
        }
    }
}