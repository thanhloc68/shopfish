using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopFish.ViewModels
{
    public class ResignViewModel
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
        [Display(Name = "Tên đăng nhập")]
        public string Usernames { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        [StringLength(100, ErrorMessage = "Mật khẩu phải dài ít nhất {2} ký tự", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Passwords { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Passwords", ErrorMessage = "Mật khẩu và mật khẩu xác nhận không khớp.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        [Display(Name = "Tên người dùng")]
        public string NameUser { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập giới tính")]
        [Display(Name = "Giới tính")]
        public string Gender { get; set; }
      
        [Required(ErrorMessage = "Yêu cầu nhập số điện thoại")]
        [Display(Name = "Số điện thoại")]
        [StringLength(10, ErrorMessage = "Số điện thoại chỉ được 10 số", MinimumLength = 10)]

        public string Tel { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]

        public string Addresss { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
                   ErrorMessage = "Please Enter Correct Email Address")]

        public string email { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? createsdate { get; set; }

        public int IDRole { get; set; }
    }
   
    }