using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public class BlogGroupConfig:EntityTypeConfiguration<BlogGroup>
    {
        public BlogGroupConfig()
        {
            ToTable("BlogGroup", "Blogs");
        }
    }
}
