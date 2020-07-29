using DB.Properties.models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.models
{
    public class HotelRoom

    {
        public int Id { get; set; }
        //CK both keys come together
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
