﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Properties.models
{
    public class Amenity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Nav properties
        public List<RoomAmenities> Rooms { get; set; }

    }
}