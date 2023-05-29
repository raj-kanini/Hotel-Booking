using Hotel_Booking.Model;
using Hotel_Booking.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        

        private readonly HotelDbContext _context;
        public FilterController(HotelDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("Filter")]
        public ActionResult<IEnumerable<Room>> GetInput1(int id)
        {
            try
            {
                var name = from n in _context.Rooms.Where(n => n.HId == id)
                           select "Room Id: " + n.RId + " Price: " + n.Price ;

                return Ok(name.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Count")]
        public string Get(int id)
        {
            try
            {
                var count = (from c in _context.Rooms.Where(n => n.HId == id)
                             select c).Count();
                return ("Number of records available in room's table: " + count);
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }

    }
}
