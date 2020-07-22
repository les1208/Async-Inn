﻿// <auto-generated />
using DB.Properties.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DB.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    partial class AsyncInnDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DB.Properties.models.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mini Bar"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Free use of beach rentals!"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bottomless Mimosas"
                        });
                });

            modelBuilder.Entity("DB.Properties.models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "2055 Kalia Rd",
                            City = "Honolulu",
                            Name = "Hale Koa",
                            PhoneNumber = "+1 (808) 955-0555",
                            State = "Hawaii"
                        },
                        new
                        {
                            Id = 2,
                            Address = "2259 Kalakaua",
                            City = "Honolulu",
                            Name = "The Royal Hawaiian",
                            PhoneNumber = "+1 (808) 923-7311",
                            State = "Hawaii"
                        },
                        new
                        {
                            Id = 3,
                            Address = "2005 Kalia Rd",
                            City = "Honolulu",
                            Name = "Hilton Hawaiian Village",
                            PhoneNumber = "+1 (808) 949-4321",
                            State = "Hawaii"
                        });
                });

            modelBuilder.Entity("DB.Properties.models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Layout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Layout = "1 bedroom",
                            Name = "Honu Suite"
                        },
                        new
                        {
                            Id = 2,
                            Layout = "2 bedrooms",
                            Name = "Aloha Suite"
                        },
                        new
                        {
                            Id = 3,
                            Layout = "3 bedrooms",
                            Name = "King Kamekameha"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
