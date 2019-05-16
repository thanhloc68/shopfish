using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopFish.Models
{
    public class Ordersdetails
    {
        [Key]
        public int ID { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
 


        public virtual Orders Orders { get; set; }
        public virtual Products Products { get; set; }
    }
}