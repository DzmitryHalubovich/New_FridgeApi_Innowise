﻿// <auto-generated />
using System;
using FridgeApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FridgeApi.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EFCoreDbContext))]
    [Migration("20230217093829_Product")]
    partial class Product
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FridgeApi.DataLayer.Models.Fridge", b =>
                {
                    b.Property<int>("FridgeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FridgeId"));

                    b.Property<DateTime>("CreateOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("FridgeModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OwnerName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdateOn")
                        .HasColumnType("datetime2");

                    b.HasKey("FridgeId");

                    b.HasIndex("FridgeModelId");

                    b.ToTable("Fridges");
                });

            modelBuilder.Entity("FridgeApi.DataLayer.Models.FridgeModel", b =>
                {
                    b.Property<int>("FridgeModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FridgeModelId"));

                    b.Property<DateTime>("CreateOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdateOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Year")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.HasKey("FridgeModelId");

                    b.ToTable("FridgeModels");
                });

            modelBuilder.Entity("FridgeApi.DataLayer.Models.FridgeProduct", b =>
                {
                    b.Property<int>("FridgeId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("FridgeId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("FridgeProduct");
                });

            modelBuilder.Entity("FridgeApi.DataLayer.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("DefaultQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("FridgeApi.DataLayer.Models.Fridge", b =>
                {
                    b.HasOne("FridgeApi.DataLayer.Models.FridgeModel", "FridgeModel")
                        .WithMany()
                        .HasForeignKey("FridgeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FridgeModel");
                });

            modelBuilder.Entity("FridgeApi.DataLayer.Models.FridgeProduct", b =>
                {
                    b.HasOne("FridgeApi.DataLayer.Models.Fridge", "Fridge")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("FridgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FridgeApi.DataLayer.Models.Product", "Product")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fridge");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FridgeApi.DataLayer.Models.Fridge", b =>
                {
                    b.Navigation("FridgeProducts");
                });

            modelBuilder.Entity("FridgeApi.DataLayer.Models.Product", b =>
                {
                    b.Navigation("FridgeProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
