using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DataLayer.Models.ViewModel
{
    public class ProjectGalleryViewModel
    {
        [Key]
        public int pGalleryId { get; set; }
        [Display(Name = "عنوان گالری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Title { get; set; }
        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250)]
        public string ShortDes { get; set; }
        [Display(Name = "متن اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Text { get; set; }
        [Display(Name = "نام مشتری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Customer { get; set; }
        [Display(Name = "تاریخ انجام پروژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd}")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "نام وبسایت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Website { get; set; }
        [Display(Name = "لوکیشن انجام پروژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Location { get; set; }
        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        public HttpPostedFileBase GalleryImageUpload { get; set; }
    }
}
