using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDEx.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base("scon")
            {}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}