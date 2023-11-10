using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace A22.Models
{
    public class Species
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
