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
        public DbSet<BuyerDto> Buyers  { get; set; }
        public DbSet<ProductDto> Products { get; set; }
        public DbSet<SaleDto> Sales { get; set; }
        [NotMapped]
        public DbSet<SaleDataDto> SaleDatas { get; set; }
        public DbSet<SalesPointDto> SalesPoints { get; set; }
        public DbSet<ProvidedProduct> ProvidedProducts { get; set; }



        public ApplicationContext()
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=test;Username=postgres;Password=pwd");
        }

    }
}
