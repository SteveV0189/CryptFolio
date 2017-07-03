using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CryptFolio.Models;

namespace CryptFolio.Migrations
{
    [DbContext(typeof(CryptoContext))]
    [Migration("20170701194309_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("CryptFolio.Models.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CMC_Id");

                    b.Property<double?>("Change_1Hr");

                    b.Property<double?>("Change_24Hr");

                    b.Property<double?>("Change_7D");

                    b.Property<string>("LastUpdated");

                    b.Property<double?>("MarketCap");

                    b.Property<string>("Name");

                    b.Property<int>("Rank");

                    b.Property<string>("Symbol");

                    b.Property<double?>("ValueBTC");

                    b.Property<double?>("ValueUSD");

                    b.Property<double?>("Volume");

                    b.HasKey("Id");

                    b.ToTable("Coins");
                });
        }
    }
}
