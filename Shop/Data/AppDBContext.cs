using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace Shop.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {

        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EfCoreBasicDb;Trusted_Connection=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
