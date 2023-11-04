using Microsoft.EntityFrameworkCore;

namespace OrderFood.API.OrderFood.Common.Models
{
    public partial class CNPM_Order_FoodContext : DbContext
    {
        public CNPM_Order_FoodContext()
        {
        }

        public CNPM_Order_FoodContext(DbContextOptions<CNPM_Order_FoodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<BillDetail> BillDetails { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categorys { get; set; } = null!;
        public virtual DbSet<Food> Foods { get; set; } = null!;
        public virtual DbSet<FoodImage> FoodImages { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<PaymentOrder> PaymentOrders { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<ViewBill> ViewBills { get; set; } = null!;
        public virtual DbSet<ViewFood> ViewFoods { get; set; } = null!;
        public virtual DbSet<ViewUser> ViewUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=NNHIEP\\SQLEXPRESS01;Initial Catalog=CNPM_Order_Food;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Bills_UserId");

                entity.Property(e => e.BillId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BillDetail>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.BillId, "IX_BillDetails_BillId");

                entity.HasIndex(e => e.FoodId, "IX_BillDetails_FoodId");

                entity.HasOne(d => d.Bill)
                    .WithMany()
                    .HasForeignKey(d => d.BillId);

                entity.HasOne(d => d.Food)
                    .WithMany()
                    .HasForeignKey(d => d.FoodId);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.FoodId, "IX_Carts_FoodId");

                entity.HasIndex(e => e.OrderId, "IX_Carts_OrderId");

                entity.HasOne(d => d.Food)
                    .WithMany()
                    .HasForeignKey(d => d.FoodId);

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "IX_Foods_CategoryId");

                entity.Property(e => e.FoodId).ValueGeneratedNever();

                entity.Property(e => e.FoodStatus).HasDefaultValueSql("(N'')");

                entity.Property(e => e.FoodType).HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<FoodImage>(entity =>
            {
                entity.HasIndex(e => e.FoodId, "IX_FoodImages_FoodId");

                entity.Property(e => e.FoodImageId).ValueGeneratedNever();

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.FoodImages)
                    .HasForeignKey(d => d.FoodId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Orders_UserId");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).ValueGeneratedNever();
            });

            modelBuilder.Entity<PaymentOrder>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.OrderId, "IX_PaymentOrders_OrderId");

                entity.HasIndex(e => e.PaymentId, "IX_PaymentOrders_PaymentId");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.Payment)
                    .WithMany()
                    .HasForeignKey(d => d.PaymentId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_Users_RoleId");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Email).HasDefaultValueSql("(N'')");

                entity.Property(e => e.FullName).HasDefaultValueSql("(N'')");

                entity.Property(e => e.PhoneNumber).HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<ViewBill>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewBill");
            });

            modelBuilder.Entity<ViewFood>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewFood");
            });

            modelBuilder.Entity<ViewUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
