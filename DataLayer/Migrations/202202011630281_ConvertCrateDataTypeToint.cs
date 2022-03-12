namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConvertCrateDataTypeToint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Blogs.Blog", "visit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Blogs.Blog", "visit", c => c.String());
        }
    }
}
