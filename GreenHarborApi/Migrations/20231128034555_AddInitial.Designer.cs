﻿// <auto-generated />
using GreenHarborApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenHarborApi.Migrations
{
    [DbContext(typeof(GreenHarborApiContext))]
    [Migration("20231128034555_AddInitial")]
    partial class AddInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GreenHarborApi.Models.Compost", b =>
                {
                    b.Property<int>("CompostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("ContactName")
                        .HasColumnType("longtext");

                    b.Property<string>("ContactPhone")
                        .HasColumnType("longtext");

                    b.Property<string>("Contents")
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.Property<string>("Zip")
                        .HasColumnType("longtext");

                    b.HasKey("CompostId");

                    b.ToTable("Composts");

                    b.HasData(
                        new
                        {
                            CompostId = 1,
                            ContactEmail = "",
                            ContactName = "",
                            ContactPhone = "",
                            Contents = "",
                            Location = "Near road marker 43, by the red barn"
                        },
                        new
                        {
                            CompostId = 2,
                            ContactEmail = "",
                            ContactName = "",
                            ContactPhone = "",
                            Contents = "",
                            Location = "Past HR rd, end of the gravel driveway"
                        },
                        new
                        {
                            CompostId = 3,
                            ContactEmail = "",
                            ContactName = "",
                            ContactPhone = "",
                            Contents = "",
                            Location = "Middle of town, near the post office"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
