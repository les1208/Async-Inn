﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Properties.models
{
    public class Room
    {
     
        public int Id { get; set; }

        public string Name { get; set; }

        public string Layout { get; set; }
        //Nav properties
        public List<RoomAmenities> Amenities { get; set; }
    }
}
