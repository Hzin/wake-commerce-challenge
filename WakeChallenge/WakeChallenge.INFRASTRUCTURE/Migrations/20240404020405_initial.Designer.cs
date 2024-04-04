﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WakeChallenge.INFRASTRUCTURE.Context;

#nullable disable

namespace WakeChallenge.INFRASTRUCTURE.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240404020405_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WakeChallenge.CORE.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("ProductId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "Refrigerante X",
                            Stock = 100,
                            Value = 10.90m
                        },
                        new
                        {
                            ProductId = 2,
                            Name = "Bolo de cenoura",
                            Stock = 5,
                            Value = 25.99m
                        },
                        new
                        {
                            ProductId = 3,
                            Name = "Leite condensado",
                            Stock = 23,
                            Value = 7.60m
                        },
                        new
                        {
                            ProductId = 4,
                            Name = "Creme de leite",
                            Stock = 45,
                            Value = 3.25m
                        },
                        new
                        {
                            ProductId = 5,
                            Name = "Barra de chocolate",
                            Stock = 111,
                            Value = 10.33m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
