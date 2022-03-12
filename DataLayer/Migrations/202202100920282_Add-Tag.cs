namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTag : DbMigration
    {
        public override void Up()
        {
            AddColumn("Blogs.Blog", "BlogTag", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Blogs.Blog", "BlogTag");
        }
    }
}
