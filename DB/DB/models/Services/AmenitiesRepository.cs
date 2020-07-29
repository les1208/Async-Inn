using DB.models.Interfaces;
using DB.Properties.Data;
using DB.Properties.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.models.Services
{
    public class AmenitiesRepository : IAmenities
    {
        private AsyncInnDbContext _context;

        public AmenitiesRepository(AsyncInnDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// creates a new amenity in db
        /// </summary>
        /// <param name="amenity"></param>
        /// <returns>succes in adding amenity</returns>
        public async Task<Amenity> Create(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task Delete(int id)
        {
            Amenity amenity = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            var amenities = await _context.Amenities.ToListAsync();
            return amenities;
        }

        public async Task<Amenity> GetAmenity(int id)
        {
            Amenity result = await _context.Amenities.FindAsync(id);
            var rooms = await _context.RoomAmenities.Where(x => x.AmenityId == id)
                                                    .Include(x => x.Room)
                                                    .ToListAsync();
            result.Rooms = rooms;
            return result;
        }

        public async Task<Amenity> Update(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
