namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredImagetype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjectGalleries", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectGalleries", "ImageName", c => c.String(nullable: false));
        }
    }
}
