using Ecomarce.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace Ecomarce.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerID);
            modelBuilder.Entity<OrderItems>().HasOne(x => x.Order).WithMany(x => x.OrderItems).HasForeignKey(x => x.OrderID);
            modelBuilder.Entity<OrderItems>().HasOne(x => x.Product).WithMany(x => x.OrderItems).HasForeignKey(x => x.ProductID);
            modelBuilder.Entity<OrderItems>().HasKey(x => new {x.OrderItemsID,x.OrderID,x.ProductID});
        }
    }
}
