﻿// <auto-generated />
using System;
using EuroMillionsAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EuroMillionsAPI.API.Migrations
{
    [DbContext(typeof(EuromillionDbContext))]
    partial class EuromillionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EuroMillionsAPI.Entities.Draw", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DrawDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Number1")
                        .HasColumnType("int");

                    b.Property<int>("Number2")
                        .HasColumnType("int");

                    b.Property<int>("Number3")
                        .HasColumnType("int");

                    b.Property<int>("Number4")
                        .HasColumnType("int");

                    b.Property<int>("Number5")
                        .HasColumnType("int");

                    b.Property<int>("Star1")
                        .HasColumnType("int");

                    b.Property<int>("Star2")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Draws");
                });
#pragma warning restore 612, 618
        }
    }
}
