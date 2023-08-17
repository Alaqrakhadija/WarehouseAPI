﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Warehouse.API.DbContexts;

#nullable disable

namespace Warehouse.API.Migrations
{
    [DbContext(typeof(WarehouseContext))]
    [Migration("20230817123752_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Warehouse.API.Entities.Container", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Containers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "40 ft HC"
                        },
                        new
                        {
                            Id = 2,
                            Type = "20 ft FR"
                        },
                        new
                        {
                            Id = 3,
                            Type = "40 ft HC"
                        });
                });

            modelBuilder.Entity("Warehouse.API.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Dimensions")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Dimensions = 1
                        },
                        new
                        {
                            Id = 2,
                            Dimensions = 2
                        },
                        new
                        {
                            Id = 3,
                            Dimensions = 3
                        },
                        new
                        {
                            Id = 4,
                            Dimensions = 4
                        },
                        new
                        {
                            Id = 5,
                            Dimensions = 5
                        });
                });

            modelBuilder.Entity("Warehouse.API.Entities.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContainerId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Dimensions")
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("SpecialInstructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("LocationId");

                    b.ToTable("Packages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContainerId = 1,
                            CustomerId = 1,
                            Dimensions = 1,
                            SpecialInstructions = "dangerous",
                            Type = "box"
                        },
                        new
                        {
                            Id = 2,
                            ContainerId = 2,
                            CustomerId = 1,
                            Dimensions = 2,
                            SpecialInstructions = "perishable",
                            Type = "box"
                        },
                        new
                        {
                            Id = 3,
                            ContainerId = 1,
                            CustomerId = 1,
                            Dimensions = 3,
                            SpecialInstructions = "dangerous",
                            Type = "cylinder"
                        },
                        new
                        {
                            Id = 4,
                            ContainerId = 1,
                            CustomerId = 2,
                            Dimensions = 4,
                            SpecialInstructions = "perishable",
                            Type = "cylinder"
                        },
                        new
                        {
                            Id = 5,
                            ContainerId = 2,
                            CustomerId = 2,
                            Dimensions = 1,
                            SpecialInstructions = "dangerous",
                            Type = "cylinder"
                        },
                        new
                        {
                            Id = 6,
                            ContainerId = 3,
                            CustomerId = 2,
                            Dimensions = 5,
                            SpecialInstructions = "perishable",
                            Type = "box"
                        },
                        new
                        {
                            Id = 7,
                            ContainerId = 3,
                            CustomerId = 3,
                            Dimensions = 5,
                            SpecialInstructions = "dangerous",
                            Type = "box"
                        });
                });

            modelBuilder.Entity("Warehouse.API.Entities.SchedulingProcess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ActualInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ActualOutDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpectedInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpectedOutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("PackageId")
                        .IsUnique();

                    b.ToTable("SchedulingProcess");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActualInDate = new DateTime(2023, 8, 17, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6928),
                            ExpectedInDate = new DateTime(2023, 8, 17, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6895),
                            ExpectedOutDate = new DateTime(2023, 8, 20, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6926),
                            LocationId = 1,
                            PackageId = 1
                        },
                        new
                        {
                            Id = 2,
                            ExpectedInDate = new DateTime(2023, 8, 20, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6932),
                            ExpectedOutDate = new DateTime(2023, 8, 22, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6934),
                            LocationId = 4,
                            PackageId = 4
                        },
                        new
                        {
                            Id = 3,
                            ActualInDate = new DateTime(2023, 8, 15, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6939),
                            ExpectedInDate = new DateTime(2023, 8, 14, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6936),
                            ExpectedOutDate = new DateTime(2023, 8, 19, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6937),
                            LocationId = 2,
                            PackageId = 2
                        },
                        new
                        {
                            Id = 4,
                            ExpectedInDate = new DateTime(2023, 8, 11, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6941),
                            ExpectedOutDate = new DateTime(2023, 8, 16, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6942),
                            LocationId = 3,
                            PackageId = 3
                        },
                        new
                        {
                            Id = 5,
                            ActualInDate = new DateTime(2023, 8, 13, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6947),
                            ActualOutDate = new DateTime(2023, 8, 16, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6948),
                            ExpectedInDate = new DateTime(2023, 8, 13, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6944),
                            ExpectedOutDate = new DateTime(2023, 8, 16, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6945),
                            LocationId = 1,
                            PackageId = 5
                        },
                        new
                        {
                            Id = 6,
                            ActualInDate = new DateTime(2023, 8, 12, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6953),
                            ActualOutDate = new DateTime(2023, 8, 14, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6954),
                            ExpectedInDate = new DateTime(2023, 8, 11, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6950),
                            ExpectedOutDate = new DateTime(2023, 8, 14, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6952),
                            LocationId = 5,
                            PackageId = 6
                        },
                        new
                        {
                            Id = 7,
                            ActualInDate = new DateTime(2023, 8, 15, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6959),
                            ActualOutDate = new DateTime(2023, 8, 16, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6960),
                            ExpectedInDate = new DateTime(2023, 8, 14, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6956),
                            ExpectedOutDate = new DateTime(2023, 8, 16, 15, 37, 52, 743, DateTimeKind.Local).AddTicks(6957),
                            LocationId = 5,
                            PackageId = 7
                        });
                });

            modelBuilder.Entity("Warehouse.API.Entities.SupplierContainer", b =>
                {
                    b.Property<int>("ContainerId")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("ContainerId", "SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("SupplierContainer");

                    b.HasData(
                        new
                        {
                            ContainerId = 1,
                            SupplierId = 4
                        },
                        new
                        {
                            ContainerId = 2,
                            SupplierId = 4
                        },
                        new
                        {
                            ContainerId = 1,
                            SupplierId = 5
                        },
                        new
                        {
                            ContainerId = 3,
                            SupplierId = 5
                        },
                        new
                        {
                            ContainerId = 2,
                            SupplierId = 6
                        });
                });

            modelBuilder.Entity("Warehouse.API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Warehouse.API.Entities.Customer", b =>
                {
                    b.HasBaseType("Warehouse.API.Entities.User");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "khadija"
                        },
                        new
                        {
                            Id = 2,
                            Name = "sara"
                        },
                        new
                        {
                            Id = 3,
                            Name = "laith"
                        });
                });

            modelBuilder.Entity("Warehouse.API.Entities.Supplier", b =>
                {
                    b.HasBaseType("Warehouse.API.Entities.User");

                    b.ToTable("Supplier");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Name = "Yousif Supplier"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Amro Supplier"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Ahmad Supplier"
                        });
                });

            modelBuilder.Entity("Warehouse.API.Entities.Package", b =>
                {
                    b.HasOne("Warehouse.API.Entities.Customer", null)
                        .WithMany("Packages")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse.API.Entities.Location", null)
                        .WithMany("Packages")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("Warehouse.API.Entities.SchedulingProcess", b =>
                {
                    b.HasOne("Warehouse.API.Entities.Location", null)
                        .WithMany("Schedulings")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse.API.Entities.Package", null)
                        .WithOne("SchedulingProcess")
                        .HasForeignKey("Warehouse.API.Entities.SchedulingProcess", "PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Warehouse.API.Entities.SupplierContainer", b =>
                {
                    b.HasOne("Warehouse.API.Entities.Container", null)
                        .WithMany("SupplierContainer")
                        .HasForeignKey("ContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse.API.Entities.Supplier", null)
                        .WithMany("SupplierContainer")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Warehouse.API.Entities.Customer", b =>
                {
                    b.HasOne("Warehouse.API.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Warehouse.API.Entities.Customer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Warehouse.API.Entities.Supplier", b =>
                {
                    b.HasOne("Warehouse.API.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Warehouse.API.Entities.Supplier", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Warehouse.API.Entities.Container", b =>
                {
                    b.Navigation("SupplierContainer");
                });

            modelBuilder.Entity("Warehouse.API.Entities.Location", b =>
                {
                    b.Navigation("Packages");

                    b.Navigation("Schedulings");
                });

            modelBuilder.Entity("Warehouse.API.Entities.Package", b =>
                {
                    b.Navigation("SchedulingProcess")
                        .IsRequired();
                });

            modelBuilder.Entity("Warehouse.API.Entities.Customer", b =>
                {
                    b.Navigation("Packages");
                });

            modelBuilder.Entity("Warehouse.API.Entities.Supplier", b =>
                {
                    b.Navigation("SupplierContainer");
                });
#pragma warning restore 612, 618
        }
    }
}