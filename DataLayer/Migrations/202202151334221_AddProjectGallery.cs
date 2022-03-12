namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectGallery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectGalleries",
                c => new
                    {
                        pGalleryId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        ShortDes = c.String(nullable: false, maxLength: 250),
                        Text = c.String(nullable: false),
                        Customer = c.String(nullable: false, maxLength: 200),
                        CreateDate = c.DateTime(nullable: false),
                        Website = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        ImageName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.pGalleryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProjectGalleries");
        }
    }
}
