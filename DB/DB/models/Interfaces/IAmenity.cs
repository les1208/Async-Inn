using DB.Properties.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.models.Interfaces
{
    public interface IAmenity
    {
        //Contains Methods and properties that are requiered for the classes to implement 

        //Create
        Amenity Create(Amenity amenity);

        //Read
        //Get All
        List<Amenity> GetAmenities();

        //Get individually (by id)
        Amenity GetAmenity(int id);

        //Update
        Amenity Update(int id, Amenity amenity);

        //Delete
        void Delete(int id);
    }
}
