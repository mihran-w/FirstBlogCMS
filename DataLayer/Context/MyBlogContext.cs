using DataLayer.Mapping;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
   public class MyBlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogComment> blogComments { get; set; }
        public DbSet<BlogGroup> blogGroups { get; set; }
        public DbSet<Logo> logos { get; set; }
        public DbSet<Slider> sliders { get; set; }
        public DbSet<AdminLogins> adminLogins { get; set; }
        public DbSet<ProjectGallery> projectGalleries { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new BlogCommentConfig());
            modelBuilder.Configurations.Add(new BlogGroupConfig());
            modelBuilder.Configurations.Add(new BlogConfig());
            modelBuilder.Configurations.Add(new SliderConfig());
            modelBuilder.Configurations.Add(new LogoConfig());

        }

    }
}
