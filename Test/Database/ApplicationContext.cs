using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Buyer> Buyers  { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        [NotMapped]
        public DbSet<SaleData> SaleDatas { get; set; }
        public DbSet<SalesPoint> SalesPoints { get; set; }
        public DbSet<ProvidedProduct> providedProducts { get; set; }



        public ApplicationContext()
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=test;Username=postgres;Password=123");
        }

    }
}
