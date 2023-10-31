using Microsoft.EntityFrameworkCore;
using OrderFood.Common.Models;

namespace OrderFood.DL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentOrder> PaymentOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodImage> FoodImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
               .HasOne(u => u.Role)
               .WithMany()
               .HasForeignKey(u => u.RoleId);
                }
    }
}
