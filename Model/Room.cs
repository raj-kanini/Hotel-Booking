using System.ComponentModel.DataAnnotations;

namespace Hotel_Booking.Model
{
    public class Room
    {
        [Key]
        public int RId { get; set; }

        public string? RoomType { get; set; }
        public bool Availability { get; set; }

        public string? RoomNumber { get; set; }

        public int Price { get; set; }
        public int HId { get; set; }
        public Hotel? Hotel { get; set; }

    }
}
