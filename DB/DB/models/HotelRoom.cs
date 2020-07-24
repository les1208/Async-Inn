using DB.Properties.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.models
{
    public class HotelRoom
    {   //CK both keys come together
        public int HotelId { get; set; }

        public int RoomNumber { get; set; }

        public int RoomId { get; set; }

        public decimal Rate { get; set; }

        public bool PetFriendly { get; set; }

        //Navigation Property
        public Hotel Hotel { get; set; }

        public Room Room { get; set; }
    }
}
