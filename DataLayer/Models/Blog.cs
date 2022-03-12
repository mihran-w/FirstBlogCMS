using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer.Models
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را انتخاب کنید")]
        public int GroupID { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }
        [Display(Name = "متن اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string BlogText { get; set; }
        [Display(Name = "بازدید")]
        public int visit { get; set; }
        [Display(Name = "تصویر")]
        public string ImageName { get; set; }
        [Display(Name = "تاریخ ایحاد")]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd}")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "برچسب ها")]
        public string BlogTag { get; set; }
        public virtual BlogGroup BlogGroup { get; set; }

        public virtual ICollection<BlogComment> BlogComments { get; set; }
    }
}
