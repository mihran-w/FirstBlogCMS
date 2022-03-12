using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataLayer.Models.ViewModel
{
    public class LogoViewModel
    {
        [Key]
        public int LogoID { get; set; }
        [Display(Name = "عنوان لوگو")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string Title { get; set; }
        [Display(Name = "تصویر لوگو")]
        public string ImageName { get; set; }

        // For Upload Image
        public HttpPostedFileBase LogoImageUpload { get; set; }
    }
}
