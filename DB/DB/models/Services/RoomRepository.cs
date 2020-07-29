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
    public class RoomRepository : IRoom
        
    {   private AsyncInnDbContext _context;

        public RoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Room> Create(Room room)
        {   //Add room to db
            _context.Entry(room).State = EntityState.Added;
            //room is saved and then assigned id
            await _context.SaveChangesAsync();

            return room;
        }

        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync(); ;
        }

        public async Task<Room> GetRoom(int id)
        {
           var result = await _context.Rooms.FindAsync(id);


            //Show all amenities room has
            var amenities = await _context.RoomAmenities.Where(x => x.RoomId == id)
                                                           .Include(x => x.Amenity)
                                                           .ToListAsync();
            result.Amenities = amenities;
            return result;
        }

        public async Task<List<Room>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return rooms;
        }

        public async Task<Room> Update(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return room;
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenities roomAmenities = new RoomAmenities()
            {
                AmenityId = amenityId,
                RoomId = roomId,
            };

            _context.Entry(roomAmenities).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            var result = await _context.RoomAmenities.FirstOrDefaultAsync(x => x.AmenityId == amenityId && x.RoomId == roomId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }

}
