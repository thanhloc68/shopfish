using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopFish.ViewModels
{
    public class ContactViewModel
    {
        [Key]
        public int ID { get; set; }
    
        [Required(ErrorMessage = "Yêu cầu nhập tên của bạn")]
        [Display(Name = "Họ tên")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Yêu cầu nhập số điện thoại")]
        [Display(Name = "Số điện thoại")]
        [StringLength(10, ErrorMessage = "Số điện thoại chỉ được 10 số", MinimumLength = 10)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
                 ErrorMessage = "Please Enter Correct Email Address")]
       
        public string email { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]
   
        public string address { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập nội dung")]
        [Display(Name = "Nội dung")]
    
        public string Content { get; set; }

 
        public DateTime? Createdate { get; set; }

      
        public bool status { get; set; }
    }

    public class BlogModelVIew
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string HeadBlog { get; set; }
        public string BodyBlog { get; set; }
        public string image1 { get; set; }
        public string FootBlog { get; set; }
        public DateTime? CreateDay { get; set; }
        public string Type { get; set; }

    }

}