using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopFish.ViewModels
{
    public class ResetPassword
    {
   
            [Key]
            public int ID { get; set; }
            [Required(ErrorMessage = "Yêu cầu nhập mật khẩu mới", AllowEmptyStrings = false)]
            [DataType(DataType.Password)]
            public string NewPassword { get; set; }
            [DataType(DataType.Password)]
            [Compare("NewPassword", ErrorMessage = "Mật khẩu không trùng")]
            public string ConfirmPassword { get; set; }
            public string ResetCode { get; set; }

    }
    public class ChangePassword
    {

        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập tên tài khoản")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu cũ")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [StringLength(100, ErrorMessage = "Mật khẩu phải dài ít nhất {2} ký tự", MinimumLength = 6)]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu mới")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [StringLength(100, ErrorMessage = "Mật khẩu phải dài ít nhất {2} ký tự", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu không trùng")]
        public string ConfirmPassword { get; set; }
      

    }
}