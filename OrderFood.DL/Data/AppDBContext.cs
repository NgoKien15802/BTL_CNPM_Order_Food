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
