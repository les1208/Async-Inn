using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Properties.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DB.models;
using DB.models.Interfaces;


namespace DB.models.Services
{
    public class HotelRepo : IHotel
    {

        private AsyncInnDbContext _context;

        public HotelRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return hotel;
        }

        public async Task Delete(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            return hotel;
        }

        public async Task<List<Hotel>> GetHotels()
        {
           var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        public async Task<Hotel> Update(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return hotel;
        }

        Task<ActionResult<IEnumerable<Hotel>>> IHotel.GetHotels()
        {
            throw new NotImplementedException();
        }
    }

}


