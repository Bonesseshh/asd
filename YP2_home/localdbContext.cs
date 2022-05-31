using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace YP2_home
{
    public partial class localdbContext : DbContext
    {
        public localdbContext()
        {
            Database.EnsureCreated();
        }

        public localdbContext(DbContextOptions<localdbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Dish> Dishes { get; set; } = null!;
        public virtual DbSet<DishInOrder> DishInOrders { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=localdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>(entity =>
            {
                entity.HasKey(e => e.IdDish)
                    .HasName("PK_Table_1");

                entity.ToTable("Dish");

                entity.Property(e => e.IdDish).HasColumnName("ID_Dish");

                entity.Property(e => e.NameDish)
                    .HasMaxLength(50)
                    .HasColumnName("Name_Dish");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.TimeDish)
                    .HasMaxLength(50)
                    .HasColumnName("Time_Dish");
            });

            modelBuilder.Entity<DishInOrder>(entity =>
            {
                entity.HasKey(e => e.IdDio);

                entity.ToTable("DishInOrder");

                entity.Property(e => e.IdDish).HasColumnName("IdDIsh");

                entity.HasOne(d => d.IdDishNavigation)
                    .WithMany(p => p.DishInOrders)
                    .HasForeignKey(d => d.IdDish)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DishInOrder_Dish");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.DishInOrders)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DishInOrder_Order");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.IdStatus).HasColumnName("ID_Status");

                entity.Property(e => e.IdUsers).HasColumnName("ID_Users");

                entity.Property(e => e.Sum).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Status");

                entity.HasOne(d => d.IdUsersNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdUsers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.ToTable("Role");

                entity.Property(e => e.IdRole).HasColumnName("ID_Role");

                entity.Property(e => e.NameRole)
                    .HasMaxLength(50)
                    .HasColumnName("Name_Role");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("Status_ID");

                entity.Property(e => e.NameStatus)
                    .HasMaxLength(50)
                    .HasColumnName("Name_Status");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.IdRole).HasColumnName("ID_Role");

                entity.Property(e => e.LoginUs)
                    .HasMaxLength(50)
                    .HasColumnName("Login_us");

                entity.Property(e => e.NameUser)
                    .HasMaxLength(50)
                    .HasColumnName("Name_User");

                entity.Property(e => e.PasswordUs)
                    .HasMaxLength(50)
                    .HasColumnName("Password_us");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
