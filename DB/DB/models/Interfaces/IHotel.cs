﻿using DB.Properties.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.models.Interfaces
{
    public interface IHotel
    {
        // contain methods and properties that are requiered for the classes to implement 

        //Create
        Task<Hotel> Create(Hotel hotel);

        //Read
        //Get All
        Task<List<Hotel>> GetHotels();

        //Get individually (by Id)
        Task<Hotel> GetHotel(int id);

        //Update
        Task<Hotel> Update(Hotel hotel);

        //Delete
        Task Delete(int id);

        Task AddRoom(int hotelId, int roomNumber, int roomId, bool petFriendly, decimal rate);
    }
}

