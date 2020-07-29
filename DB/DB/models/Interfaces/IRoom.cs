using DB.Properties.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.models.Interfaces
{
   public interface IRoom
    {
        // contain methods and properties that are requiered for the classes to implement 

        //Create
        Task<Room> Create(Room room);

        //Read
        //Get All
        Task<List<Room>> GetRooms();

        //Get individually (by Id)
        Task<Room> GetRoom(int id);

        //Update
        Task<Room> Update(Room room);

        //Delete
        Task Delete(int id);

        ///<summary>
        ///adds amenity to room
        ///<param name="amenityId"/> unique id of amenity </param>
        ///<param name="roomId"> unique id of room</param>
        ///<returns>task completed</returns>
        ///</summary>
        Task AddAmenityToRoom(int amenityId, int roomId);
        ///Removes an amenity from room
        ///<param name="AmenityId"/> unique id of amenity </param>
        ///<param name="RoomId"/>unique id of amenity </param>
        ///</summary>
        Task RemoveAmenityFromRoom(int amenityId, int roomId);
    }
}
