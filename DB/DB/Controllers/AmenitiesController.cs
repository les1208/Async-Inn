using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DB.Properties.Data;
using DB.Properties.models;
using DB.models.Interfaces;

namespace DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenities _amenity;

        public AmenitiesController(IAmenities amenity)
        {
            _amenity = amenity;
        }

        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
        {
            return await _amenity.GetAmenities();
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenity>> GetAmenity(int id)
        {
           return await _amenity.GetAmenity(id);
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, Amenity amenity)
        {
            if (id != amenity.Id)
            {
                return BadRequest();
            }

            var updatedAmenity = await _amenity.Update(amenity);
            return Ok(updatedAmenity);
        }

        // POST: api/Amenities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Amenity>> PostAmenity(Amenity amenity)
        {
            await _amenity.Create(amenity);
            return CreatedAtAction("GetAmenity", new { id = amenity.Id }, amenity);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Amenity>> DeleteAmenity(int id)
        {
            await _amenity.Delete(id);
            return NoContent();
        }
    }
}
