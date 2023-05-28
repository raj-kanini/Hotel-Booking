using Hotel_Booking.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly IFilter _hotelRepository;

        public FilterController(IFilter hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        [HttpGet]
        public IActionResult GetAllHotels(string location = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var hotels = _hotelRepository.GetFilteredHotels(location, minPrice, maxPrice);
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public int GetCount(int id)
        {
            var res = _hotelRepository.Results(id);

            return res;
        }

    }
}
