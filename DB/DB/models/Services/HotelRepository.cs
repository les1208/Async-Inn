using DB.Controllers;
using DB.Migrations;
using DB.models.Interfaces;
using DB.Properties.Data;
using DB.Properties.models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.models.Services
{
    public class HotelRepository : IHotel
    {

        private AsyncInnDbContext _context;

        public HotelRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// creates new hotel in db
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>returns hotel succesfully </returns>
        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return hotel;
        }

        /// <summary>
        /// deletes selected hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns>success in deleted hotel</returns>
        public async Task Delete(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// gets selected hotel from db
        /// </summary>
        /// <param name="id"></param>
        /// <returns>succes in returning selected hotel</returns>
        public async Task<Hotel> GetHotel(int id)
        {
            Hotel result = await _context.Hotels.FindAsync(id);
            var rooms = await _context.HotelRooms.Where(x => x.HotelId == id)
                                                .Include(x => x.Room)
                                                .ToListAsync();
            result.Rooms = rooms;
            return result;
        }

        /// <summary>
        /// returns all hotels to db
        /// </summary>
        /// <returns>returns list fo all hotels</returns>
        public async Task<List<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        /// <summary>
        /// updates details of selected hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>updated hotel</returns>
        public async Task<Hotel> Update(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return hotel;
        }

        /// <summary>
        /// adds room to selected hotel
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="roomId"></param>
        /// <returns>task succesful </returns>
        public async Task AddRoom(int hotelId, int roomNumber, int roomId, bool petFriendly, decimal rate)
        {
            HotelRoom hotelRoom = new HotelRoom()
            {
                HotelId = hotelId,
                RoomNumber = roomNumber,
                RoomId = roomId,
                PetFriendly = petFriendly,
                Rate = rate
            };
            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

    }

}

