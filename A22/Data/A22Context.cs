using A22.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace A22.Data
{
    public class A22Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public A22Context() : base("name=A22Context")
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Species> Species { get; set; }
    }
}
