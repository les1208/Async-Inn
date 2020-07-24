using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Properties.models
{
    public class RoomAmenities
    {  
        /// <summary>
        /// Our composite key is both keys together combined
        /// </summary>
        public int AmenityId { get; set; }

        public int RoomId { get; set; }

        //Navigation property
        public Room Room { get; set; }

        public Amenity Amenity { get; set; }
    }
}


