namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSliderTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Sliders.Slider", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("Sliders.Slider", "ImageName", c => c.String(nullable: false));
        }
    }
}
