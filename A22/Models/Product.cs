using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace A22.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string Img { get; set; }
        public string Name { get; set; }
        public string Dscription { get; set; }
        public int Price { get; set; }
        public int SpId { get; set; }
        public virtual Species sp { get; set; }
    }
}