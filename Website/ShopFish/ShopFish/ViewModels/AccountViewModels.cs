using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ShopFish.Models;

namespace ShopFish.ViewModels
{
    public class AccountViewModels
    {
        public class LoginViewModel
        {
            [Key]
            [Required]
            [Display(Name = "Tên đăng nhập")]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Mật khẩu")]
            public string Password { get; set; }

        
        }

     
    }
 
}