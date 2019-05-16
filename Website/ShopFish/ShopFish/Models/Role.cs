using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopFish.Models
{
    public class Role
    {
        [Key]
        public int IDRole { get; set; }
        public string Name { get; set; }

        public virtual List<Accounts> Accounts { get; set; }
    }
}