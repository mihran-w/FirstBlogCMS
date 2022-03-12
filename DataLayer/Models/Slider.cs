using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Slider
    {
        [Key]
        public int SlideID { get; set; }
        [Display(Name ="عنوان")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید.")]
        [MaxLength(150)]
        public string Title { get; set; }
        [Display(Name = "تصویر")]
        public string ImageName { get; set; }
        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [DisplayFormat(DataFormatString ="{0:yyyy/mm/dd}")]
        public DateTime StartDate { get; set; }
        [Display(Name = "تاریخ پایان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd}")]
        public DateTime EndDate { get; set; }
        [Display(Name ="وضعیت")]
        public bool IsActive { get; set; }
        [Display(Name ="لینک")]
        [Url(ErrorMessage ="لطفا لینک را به درستی و با فرمت مناسب وارد کنید")]
        public string Url { get; set; }
    }
}
