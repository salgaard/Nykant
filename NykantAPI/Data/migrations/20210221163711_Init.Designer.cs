﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NykantAPI.Data;

namespace NykantAPI.Data.migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210221163711_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NykantAPI.Models.BagItem", b =>
                {
                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Subject", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("BagItems");
                });

            modelBuilder.Entity("NykantAPI.Models.CustomerInf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postal")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("CustomerInfs");
                });

            modelBuilder.Entity("NykantAPI.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 2,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 3,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 4,
                            ProductId = 4,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 5,
                            ProductId = 5,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 6,
                            ProductId = 6,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 7,
                            ProductId = 7,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 8,
                            ProductId = 8,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 9,
                            ProductId = 9,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 10,
                            ProductId = 10,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 11,
                            ProductId = 11,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 12,
                            ProductId = 12,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 13,
                            ProductId = 13,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 14,
                            ProductId = 14,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 15,
                            ProductId = 15,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 16,
                            ProductId = 16,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 17,
                            ProductId = 17,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 18,
                            ProductId = 18,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 19,
                            ProductId = 19,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 20,
                            ProductId = 1,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 21,
                            ProductId = 2,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 22,
                            ProductId = 3,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 23,
                            ProductId = 4,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 24,
                            ProductId = 5,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 25,
                            ProductId = 6,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 26,
                            ProductId = 7,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 27,
                            ProductId = 8,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 28,
                            ProductId = 9,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 29,
                            ProductId = 10,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 30,
                            ProductId = 11,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 31,
                            ProductId = 12,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 32,
                            ProductId = 13,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 33,
                            ProductId = 14,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 34,
                            ProductId = 15,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 35,
                            ProductId = 16,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 36,
                            ProductId = 17,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 37,
                            ProductId = 18,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        },
                        new
                        {
                            Id = 38,
                            ProductId = 19,
                            Source = "../images/Finback-Chairs1-1280x853-c-default.jpg"
                        });
                });

            modelBuilder.Entity("NykantAPI.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerInfId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentIntent_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShippingDeliveryId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerInfId");

                    b.HasIndex("ShippingDeliveryId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("NykantAPI.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("NykantAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageSource2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfWood")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "stol",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 88, DateTimeKind.Local).AddTicks(5948),
                            Price = 1000,
                            Size = "5mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "valnød"
                        },
                        new
                        {
                            Id = 2,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "stol",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7604),
                            Price = 1000,
                            Size = "10mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "eg"
                        },
                        new
                        {
                            Id = 3,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "bænk",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7674),
                            Price = 1000,
                            Size = "20mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "fyr"
                        },
                        new
                        {
                            Id = 4,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "skærebræt",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7680),
                            Price = 1000,
                            Size = "5mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "eg"
                        },
                        new
                        {
                            Id = 5,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "bænk",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7683),
                            Price = 1000,
                            Size = "10mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "valnød"
                        },
                        new
                        {
                            Id = 6,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "skærebræt",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7685),
                            Price = 1000,
                            Size = "20mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "fyr"
                        },
                        new
                        {
                            Id = 7,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "stol",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7688),
                            Price = 1000,
                            Size = "5mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "valnød"
                        },
                        new
                        {
                            Id = 8,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "stol",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7691),
                            Price = 1000,
                            Size = "10mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "eg"
                        },
                        new
                        {
                            Id = 9,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "bænk",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7693),
                            Price = 1000,
                            Size = "20mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "fyr"
                        },
                        new
                        {
                            Id = 10,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "skærebræt",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7696),
                            Price = 1000,
                            Size = "5mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "eg"
                        },
                        new
                        {
                            Id = 11,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "bænk",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7700),
                            Price = 1000,
                            Size = "10mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "valnød"
                        },
                        new
                        {
                            Id = 12,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "skærebræt",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7702),
                            Price = 1000,
                            Size = "20mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "fyr"
                        },
                        new
                        {
                            Id = 13,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "stol",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7705),
                            Price = 1000,
                            Size = "5mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "valnød"
                        },
                        new
                        {
                            Id = 14,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "stol",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7708),
                            Price = 1000,
                            Size = "10mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "eg"
                        },
                        new
                        {
                            Id = 15,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "bænk",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7710),
                            Price = 1000,
                            Size = "20mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "fyr"
                        },
                        new
                        {
                            Id = 16,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "skærebræt",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7713),
                            Price = 1000,
                            Size = "5mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "eg"
                        },
                        new
                        {
                            Id = 17,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "bænk",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7757),
                            Price = 1000,
                            Size = "10mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "valnød"
                        },
                        new
                        {
                            Id = 18,
                            Color = "farvet-overflade",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "skærebræt",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7761),
                            Price = 1000,
                            Size = "20mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "fyr"
                        },
                        new
                        {
                            Id = 19,
                            Color = "naturligt",
                            Description = "a test object",
                            ImageSource = "../images/Finback-Chairs1-1280x853-c-default.jpg",
                            ImageSource2 = "../images/gyngestol.jpg",
                            ItemType = "bænk",
                            LastModified = new DateTime(2021, 2, 21, 17, 37, 1, 90, DateTimeKind.Local).AddTicks(7763),
                            Price = 1000,
                            Size = "5mm",
                            Title = "Grøntsags Skærebræt",
                            TypeOfWood = "valnød"
                        });
                });

            modelBuilder.Entity("NykantAPI.Models.ShippingDelivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ShippingDeliveries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "GLS",
                            Price = 35
                        },
                        new
                        {
                            Id = 2,
                            Name = "PostNord",
                            Price = 50
                        },
                        new
                        {
                            Id = 3,
                            Name = "GLS Privat",
                            Price = 65
                        });
                });

            modelBuilder.Entity("NykantAPI.Models.BagItem", b =>
                {
                    b.HasOne("NykantAPI.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NykantAPI.Models.Image", b =>
                {
                    b.HasOne("NykantAPI.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NykantAPI.Models.Order", b =>
                {
                    b.HasOne("NykantAPI.Models.CustomerInf", "CustomerInf")
                        .WithMany()
                        .HasForeignKey("CustomerInfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NykantAPI.Models.ShippingDelivery", "ShippingDelivery")
                        .WithMany()
                        .HasForeignKey("ShippingDeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NykantAPI.Models.OrderItem", b =>
                {
                    b.HasOne("NykantAPI.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NykantAPI.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}