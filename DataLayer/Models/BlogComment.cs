using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class BlogComment
    {
        [Key]
        public int CommentID { get; set; }
        [Display(Name = "وبلاک")]
        [Required(ErrorMessage = "لطفا {0} را انتخاب نمایید.")]
        public int BlogID { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Name { get; set; }
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Display(Name = "نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Comment { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }

        public virtual Blog Blog { get; set; }

    }
}
