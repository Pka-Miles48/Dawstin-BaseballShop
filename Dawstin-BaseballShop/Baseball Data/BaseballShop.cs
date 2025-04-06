using Dawstin_BaseballShop.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace Dawstin_BaseballShop.Baseball_Data
{
    public class BaseballShopContext : DbContext
    {
        public BaseballShopContext(DbContextOptions<BaseballShopContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CategoryID);

            base.OnModelCreating(modelBuilder);
        }
    }

}
