using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasicMvcTeach01.Models.ViewModel
{
    public class LoginModel
    {

        [DisplayName("帳號")]
        [Required(ErrorMessage = "請輸入帳號")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "帳號長度 6 ~ 12 碼之間")]
        public string Account { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }

        [DisplayName("驗證碼")]
        public string OtpKey { get; set; }
    }
}