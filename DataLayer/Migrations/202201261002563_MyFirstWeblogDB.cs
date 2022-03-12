namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyFirstWeblogDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Blogs.BlogComment",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        BlogID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        Website = c.String(),
                        Comment = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("Blogs.Blog", t => t.BlogID)
                .Index(t => t.BlogID);
            
            CreateTable(
                "Blogs.Blog",
                c => new
                    {
                        BlogID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        ShortDescription = c.String(nullable: false, maxLength: 150),
                        BlogText = c.String(nullable: false),
                        visit = c.String(),
                        ImageName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogID)
                .ForeignKey("Blogs.BlogGroup", t => t.GroupID)
                .Index(t => t.GroupID);
            
            CreateTable(
                "Blogs.BlogGroup",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.GroupID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Blogs.BlogComment", "BlogID", "Blogs.Blog");
            DropForeignKey("Blogs.Blog", "GroupID", "Blogs.BlogGroup");
            DropIndex("Blogs.Blog", new[] { "GroupID" });
            DropIndex("Blogs.BlogComment", new[] { "BlogID" });
            DropTable("Blogs.BlogGroup");
            DropTable("Blogs.Blog");
            DropTable("Blogs.BlogComment");
        }
    }
}
