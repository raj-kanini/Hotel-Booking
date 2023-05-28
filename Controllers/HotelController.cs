using Hotel_Booking.Model;
using Hotel_Booking.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Hotel_Booking.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHrepository _hotelRepository;

        public HotelController(IHrepository Hrepository)
        {
            _hotelRepository = Hrepository;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            var hotels = _hotelRepository.GetAllHotels();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public IActionResult GetHotelById(int id)
        {
            var hotel = _hotelRepository.GetHotelById(id);
            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            _hotelRepository.AddHotel(hotel);
            return CreatedAtAction(nameof(GetHotelById), new { id = hotel.HId }, hotel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHotel(int id, [FromBody] Hotel hotel)
        {
            if (id != hotel.HId)
                return BadRequest();

            _hotelRepository.UpdateHotel(hotel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            _hotelRepository.DeleteHotel(id);
            return NoContent();
        }
    }
}
