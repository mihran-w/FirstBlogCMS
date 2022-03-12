namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove : DbMigration
    {
        public override void Up()
        {
            DropColumn("Blogs.BlogComment", "Website");
        }
        
        public override void Down()
        {
            AddColumn("Blogs.BlogComment", "Website", c => c.String());
        }
    }
}
