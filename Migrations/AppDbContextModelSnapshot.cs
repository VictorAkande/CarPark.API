﻿// <auto-generated />
using System;
using CarPark.API.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarPark.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarPark.API.Models.ParkingRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EntranceFee")
                        .HasColumnType("int");

                    b.Property<int>("FirstHourCost")
                        .HasColumnType("int");

                    b.Property<int>("SuccessiveHourCost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ParkingRules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EntranceFee = 2,
                            FirstHourCost = 3,
                            SuccessiveHourCost = 4
                        });
                });

            modelBuilder.Entity("CarPark.API.Models.ParkingTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EntryTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExitTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalCost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ParkingTickets");
                });
#pragma warning restore 612, 618
        }
    }
}
