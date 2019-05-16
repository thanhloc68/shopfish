using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopFish.Models
{
    public class Orders
    {
        [Key]
        public int ID { get; set; }
        public string CustomerId { get; set; }
      
        public DateTime? OrderDate { get; set; }
        public string Receiver { get; set; }
        public string Address { get; set; }
        public string Descriptions { get; set; }
        public double Amount { get; set; }
       

        public virtual Accounts AccountsID { get; set; }
        public virtual IList<Ordersdetails> Ordersdetails { get; set; }
       
    }
}