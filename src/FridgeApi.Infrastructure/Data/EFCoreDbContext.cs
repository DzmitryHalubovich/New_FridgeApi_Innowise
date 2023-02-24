using FridgeApi.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.Infrastructure.Data
{
    public sealed class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : base(options) { }

        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<FridgeModel> FridgeModels { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Fridge>()
                .HasMany(c => c.Products)
                .WithMany(c => c.Fridges)
                .UsingEntity<FridgeProduct>(
                    j => j
                    .HasOne(c => c.Product)
                    .WithMany(c => c.FridgeProducts)
                    .HasForeignKey(c => c.ProductId),
                    j => j
                    .HasOne(c => c.Fridge)
                    .WithMany(c => c.FridgeProducts)
                    .HasForeignKey(c => c.FridgeId),
                    j =>
                    {
                        j.HasKey(t => new { t.FridgeId, t.ProductId });
                        j.ToTable("FridgeProducts");
                    });

            //Не обязательно

            //modelBuilder.Entity<FridgeProduct>()
            //    .HasOne(p => p.Fridge)
            //    .WithMany(p => p.FridgeProducts)
            //    .HasForeignKey(p => p.FridgeId);

            //modelBuilder.Entity<FridgeProduct>()
            //    .HasOne(p => p.Product)
            //    .WithMany(p => p.FridgeProducts)
            //    .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Fridge>().Property<DateTime>("CreateOn");
            modelBuilder.Entity<Fridge>().Property<DateTime>("UpdateOn");
            modelBuilder.Entity<FridgeModel>().Property<DateTime>("CreateOn");
            modelBuilder.Entity<FridgeModel>().Property<DateTime>("UpdateOn");
        }
    }
}
