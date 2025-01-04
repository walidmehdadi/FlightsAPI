﻿// <auto-generated />
using System;
using FlightsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightsAPI.Migrations
{
    [DbContext(typeof(FlightsDbContext))]
    partial class FlightsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlightsAPI.Models.Airline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AirlineCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<int>("AllianceId")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AllianceId");

                    b.ToTable("Airlines");
                });

            modelBuilder.Entity("FlightsAPI.Models.Alliance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Continent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Alliances");
                });

            modelBuilder.Entity("FlightsAPI.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AirlineId")
                        .HasColumnType("int");

                    b.Property<string>("ArrivalCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlightNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AirlineId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("FlightsAPI.Models.Airline", b =>
                {
                    b.HasOne("FlightsAPI.Models.Alliance", "Alliance")
                        .WithMany("Airlines")
                        .HasForeignKey("AllianceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alliance");
                });

            modelBuilder.Entity("FlightsAPI.Models.Flight", b =>
                {
                    b.HasOne("FlightsAPI.Models.Airline", "Airline")
                        .WithMany("Flights")
                        .HasForeignKey("AirlineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airline");
                });

            modelBuilder.Entity("FlightsAPI.Models.Airline", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("FlightsAPI.Models.Alliance", b =>
                {
                    b.Navigation("Airlines");
                });
#pragma warning restore 612, 618
        }
    }
}
