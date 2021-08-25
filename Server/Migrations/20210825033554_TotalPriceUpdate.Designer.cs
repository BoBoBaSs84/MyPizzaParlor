﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaParlor.Server.Data;

namespace PizzaParlor.Server.Migrations
{
    [DbContext(typeof(PizzaPlaceDbContext))]
    [Migration("20210825033554_TotalPriceUpdate")]
    partial class TotalPriceUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaParlor.Shared.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("PizzaParlor.Shared.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PizzaParlor.Shared.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("Spiciness")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pepperoni",
                            Price = 8.99m,
                            Spiciness = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Margarita",
                            Price = 7.99m,
                            Spiciness = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Diabolo",
                            Price = 9.99m,
                            Spiciness = 2
                        });
                });

            modelBuilder.Entity("PizzaParlor.Shared.PizzaOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("PizzaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("PizzaOrder");
                });

            modelBuilder.Entity("PizzaParlor.Shared.Order", b =>
                {
                    b.HasOne("PizzaParlor.Shared.Customer", "Customer")
                        .WithOne("Order")
                        .HasForeignKey("PizzaParlor.Shared.Order", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("PizzaParlor.Shared.PizzaOrder", b =>
                {
                    b.HasOne("PizzaParlor.Shared.Order", "Order")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("OrderId");

                    b.HasOne("PizzaParlor.Shared.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId");

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PizzaParlor.Shared.Customer", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("PizzaParlor.Shared.Order", b =>
                {
                    b.Navigation("PizzaOrders");
                });
#pragma warning restore 612, 618
        }
    }
}