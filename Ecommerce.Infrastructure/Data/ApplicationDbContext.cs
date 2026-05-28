using Ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }

        // ── Location ────────────────────────────────────────────────
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        // ── Catalogue ───────────────────────────────────────────────
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        // ── Shopping ────────────────────────────────────────────────
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<UserFavouriteProduct> UserFavouriteProducts { get; set; }

        // ── Orders ──────────────────────────────────────────────────
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderAddress> OrderAddresses { get; set; }

        // ── Payments ────────────────────────────────────────────────
        public DbSet<Transaction> Transactions { get; set; }

        // ── Engagement ──────────────────────────────────────────────
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ── User ────────────────────────────────────────────────
            builder.Entity<ApplicationUser>(e =>
            {
                e.HasKey(u => u.Id);
                e.HasIndex(u => u.UserName).IsUnique();
                e.HasIndex(u => u.Email).IsUnique();
                e.Property(u => u.Role).HasConversion<string>();
            });

            // ── UserAddress ─────────────────────────────────────────
            builder.Entity<UserAddress>(e =>
            {
                e.HasKey(a => a.Id);
                e.Property(a => a.RecipientName).HasMaxLength(100);
                e.Property(a => a.PhoneNumber).HasMaxLength(20);
                e.Property(a => a.Landmark).HasMaxLength(255);
                e.Property(a => a.ZipCode).HasMaxLength(20);

                e.HasOne(a => a.User).WithMany(u => u.Addresses).HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.Cascade);
                e.HasOne(a => a.Country).WithMany(c => c.UserAddresses).HasForeignKey(a => a.CountryId).OnDelete(DeleteBehavior.Restrict);
                e.HasOne(a => a.State).WithMany(s => s.UserAddresses).HasForeignKey(a => a.StateId).OnDelete(DeleteBehavior.Restrict);
                e.HasOne(a => a.City).WithMany(c => c.UserAddresses).HasForeignKey(a => a.CityId).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<State>(e =>
            {
                e.HasOne(s => s.Country)
                    .WithMany(c => c.States)
                    .HasForeignKey(s => s.CountryId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<City>(e =>
            {
                e.HasOne(c => c.State).WithMany(s => s.Cities).HasForeignKey(c => c.StateId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Category>(e =>
            {
                e.HasKey(c => c.Id);
                e.HasIndex(c => c.Slug).IsUnique();
                e.HasOne(c => c.ParentCategory).WithMany(c => c.SubCategories).HasForeignKey(c => c.ParentCategoryId).OnDelete(DeleteBehavior.Restrict);
                e.HasOne(c => c.CreatedByUser).WithMany().HasForeignKey(c => c.CreatedBy).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Product>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.Price).HasColumnType("decimal(18,2)");
                e.Property(p => p.StrikethroughPrice).HasColumnType("decimal(18,2)");

                e.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Restrict);
                e.HasOne(p => p.CreatedByUser).WithMany().HasForeignKey(p => p.CreatedBy).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ProductImage>(e =>
            {
                e.HasKey(i => i.Id);
                e.HasOne(i => i.Product).WithMany(p => p.Images).HasForeignKey(i => i.ProductId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<CartItem>(e =>
            {
                e.HasKey(c => c.Id);
                e.Property(c => c.Price).HasColumnType("decimal(18,2)");
                e.HasOne(c => c.User).WithMany(u => u.CartItems).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Cascade);
                e.HasOne(c => c.Product).WithMany(p => p.CartItems).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<UserFavouriteProduct>(e =>
            {
                e.HasKey(f => f.Id);
                e.HasIndex(f => new { f.UserId, f.ProductId }).IsUnique();
                e.HasOne(f => f.User).WithMany(u => u.FavouriteProducts).HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.Cascade);
                e.HasOne(f => f.Product).WithMany(p => p.FavouritedBy).HasForeignKey(f => f.ProductId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Order>(e =>
            {
                e.HasKey(o => o.Id);
                e.Property(o => o.TotalPrice).HasColumnType("decimal(10,2)");
                e.Property(o => o.ShippingFees).HasColumnType("decimal(10,2)");
                e.Property(o => o.PaymentStatus).HasConversion<string>();
                e.Property(o => o.PaymentMethod).HasConversion<string>();
                e.Property(o => o.Status).HasConversion<string>();
                e.HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<OrderItem>(e =>
            {
                e.HasKey(i => i.Id);
                e.HasIndex(i => new { i.OrderId, i.ProductId }).IsUnique();
                e.Property(i => i.UnitPrice).HasColumnType("decimal(18,2)");
                e.HasOne(i => i.Order).WithMany(o => o.Items).HasForeignKey(i => i.OrderId).OnDelete(DeleteBehavior.Cascade);
                e.HasOne(i => i.Product).WithMany(p => p.OrderItems).HasForeignKey(i => i.ProductId).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<OrderAddress>(e =>
            {
                e.HasKey(a => a.Id);
                e.HasOne(a => a.Order).WithOne(o => o.ShippingAddress).HasForeignKey<OrderAddress>(a => a.OrderId).OnDelete(DeleteBehavior.Cascade);
                e.HasOne(a => a.User).WithMany().HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Transaction>(e =>
            {
                e.HasKey(t => t.Id);
                e.Property(t => t.Amount).HasColumnType("decimal(10,2)");
                e.Property(t => t.Gateway).HasConversion<string>();
                e.Property(t => t.TransactionType).HasConversion<string>();
                e.Property(t => t.Status).HasConversion<string>();
                e.HasOne(t => t.Order).WithMany(o => o.Transactions).HasForeignKey(t => t.OrderId).OnDelete(DeleteBehavior.Cascade);
                e.HasOne(t => t.User)
                    .WithMany(u => u.Transactions)
                    .HasForeignKey(t => t.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ── Review ───────────────────────────────────────────────
            builder.Entity<Review>(e =>
            {
                e.HasKey(r => r.Id);
                e.Property(r => r.Rating).HasAnnotation("Range", "[1,5]");
                e.HasOne(r => r.User).WithMany(u => u.Reviews).HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Cascade);
                e.HasOne(r => r.Product).WithMany(p => p.Reviews).HasForeignKey(r => r.ProductId).OnDelete(DeleteBehavior.Cascade);
            });

            // ── Discount ─────────────────────────────────────────────
            builder.Entity<Discount>(e =>
            {
                e.HasKey(d => d.Id);
                e.Property(d => d.DiscountValue).HasColumnType("decimal(18,2)");
                e.Property(d => d.DiscountType).HasConversion<string>();
            });


            }
        }
    }
