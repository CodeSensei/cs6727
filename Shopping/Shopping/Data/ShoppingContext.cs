using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopping.Models;

namespace Shopping.Data
{
    public class ShoppingContext : DbContext
    {


        public ShoppingContext (DbContextOptions<ShoppingContext> options)
            : base(options)
        {
        }

        public DbSet<Shopping.Models.Product> Product { get; set; } = default!;



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>().ToTable("Product");
       
        //}



        public DbSet<Shopping.Models.Account> Account { get; set; }






    }
}
