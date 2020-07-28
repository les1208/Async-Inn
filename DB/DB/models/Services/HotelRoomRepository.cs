﻿using DB.models.Interfaces;
using DB.Properties.Data;
using DB.Properties.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.models.Services
{
    public class HotelRoomRepository : IHotelRoom
    {
        private AsyncInnDbContext _context;

        public HotelRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<HotelRoom> Create(HotelRoom hotelRoom)
        {   //Add room to db
            _context.Entry(hotelRoom).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //room is saved and then assigned id
            await _context.SaveChangesAsync();

            return hotelRoom;
        }

        public async Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber)
        {
            HotelRoom hotelRoom = await _context.HotelRooms.FindAsync(hotelId, roomNumber);
            var room = await _context.Rooms.Where(x => x.Id == hotelRoom.RoomId)
                                            .Include(x => x.RoomAmenities)                                        
                                            .ThenInclude(x => x.Amenity)
                                            .ToListAsync();

            return hotelRoom;


        }

        /// <summary>
        /// Gets all the Hotel Rooms of the selected hotel
        /// </summary>
        public async Task<List<HotelRoom>> GetHotelRooms(int hotelId)
        {
            var hotelRooms = await _context.HotelRooms.Where(x => x.HotelId == hotelId)
                                                      .Include(x => x.Room)
                                                      .ThenInclude(x => x.RoomAmenities)
                                                      .ThenInclude(x => x.Amenity)
                                                      .ToListAsync();

            return hotelRooms;
        }

        public async Task<HotelRoom> Update(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task Delete(int hotelId, int roomNumber)
        {
            HotelRoom hotelRoom = await GetHotelRoom(hotelId, roomNumber);
            _context.Entry(hotelRoom).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }



}
