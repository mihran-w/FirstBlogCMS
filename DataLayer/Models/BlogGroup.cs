﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class BlogGroup
    {
        [Key]
        public int GroupID { get; set; }
        [Display(Name = "عنوان گروه")]
        [MaxLength(150)]
        public string GroupName { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }

    }
}
