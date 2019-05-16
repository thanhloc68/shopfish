using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopFish.Models
{
    public class Blog
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

        public virtual TypeBlog TypeBlogs { get; set; }
    }
}