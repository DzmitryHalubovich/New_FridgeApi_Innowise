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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fridge>().Property<DateTime>("CreateOn");
            modelBuilder.Entity<Fridge>().Property<DateTime>("UpdateOn");
            modelBuilder.Entity<FridgeModel>().Property<DateTime>("CreateOn");
            modelBuilder.Entity<FridgeModel>().Property<DateTime>("UpdateOn");
        }
    }
}
