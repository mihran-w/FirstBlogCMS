using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class AdminLogins
    {
        [Key]
        public int LoginId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید ")]
        [MaxLength(200)]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید ")]
        [MaxLength(250)]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید ")]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
