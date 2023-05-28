using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Hotel_Booking.Model
{
    public class Hotel
    {
        [Key]
        public int HId { get; set; }
        public string? HName { get; set; }

        public string? HLocation { get; set; }

        public int Price { get; set; }
        public string? HAmenities { get; set; }

        public ICollection<Room>? Rooms { get; set; }
    }
}
