namespace ShopFish.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        [Key]
        public int ID { get; set; }


        public string Name { get; set; }

        public string Phone { get; set; }


        public string email { get; set; }

 
        public string address { get; set; }

  
        public string Content { get; set; }

     
        public DateTime? Createdate { get; set; }

     
        public bool status { get; set; }
    }
}
