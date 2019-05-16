using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopFish.Models
{
    public class Accounts
    {
        [Key]
        public int ID { get; set; }
         public string Usernames { get; set; }
      
        public string Passwords { get; set; }
       
           public string NameUser { get; set; }
                 public string Gender { get; set; }
           
            public string Tel { get; set; }
   
        public string Addresss { get; set; }
       

        public string email { get; set; }

        public string ResetPasswordCode { get; set; }
        public DateTime createsdate { get; set; }
        public int IDRole { get; set; }

        public virtual List<Orders> Orders { get; set; }
        public virtual Role Roles { get; set; }
    }
}