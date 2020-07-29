using DB.Properties.models;
using Microsoft.EntityFrameworkCore;
using DB.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DB.Properties.Data
{
    public class AsyncInnDbContext : IdentityDbContext<ApplicationUser>
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HotelRoom>().HasKey(x => new { x.HotelId, x.RoomNumber });

            modelBuilder.Entity<RoomAmenities>().HasKey(x => new { x.AmenityId, x.RoomId });



            modelBuilder.Entity<Hotel>().HasData(
             new Hotel
             {
                 Id = 1,
                 Name = "Hale Koa",
                 Address = "2055 Kalia Rd",
                 City = "Honolulu",
                 State = "Hawaii",
                 PhoneNumber = "+1 (808) 955-0555"
             },

             new Hotel
             {
                 Id = 2,
                 Name = "The Royal Hawaiian",
                 Address = "2259 Kalakaua",
                 City = "Honolulu",
                 State = "Hawaii",
                 PhoneNumber = "+1 (808) 923-7311"
             },

                new Hotel
                {
                    Id = 3,
                    Name = "Hilton Hawaiian Village",
                    Address = "2005 Kalia Rd",
                    City = "Honolulu",
                    State = "Hawaii",
                    PhoneNumber = "+1 (808) 949-4321"
                });

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    Name = "Honu Suite",
                    Layout = "1 bedroom"
                },


                new Room
                {
                    Id = 2,
                    Name = "Aloha Suite",
                    Layout = "2 bedrooms"
                },


                new Room
                {
                    Id = 3,
                    Name = "King Kamekameha",
                    Layout = "3 bedrooms"
                });

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity
                {
                    Id = 1,
                    Name = "Mini Bar",
                },

                new Amenity
                {
                    Id = 2,
                    Name = "Free use of beach rentals!"
                },

                new Amenity
                {
                    Id = 3,
                    Name = "Bottomless Mimosas"
                });
        }


        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<RoomAmenities> RoomAmenities { get; set; }

        public DbSet<HotelRoom> HotelRooms { get; set; }
    }

    }
