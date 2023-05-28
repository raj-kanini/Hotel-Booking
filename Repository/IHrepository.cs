using Hotel_Booking.Model;

namespace Hotel_Booking.Repository
{
    public interface IHrepository
    {
        Hotel GetHotelById(int id);
        IEnumerable<Hotel> GetAllHotels();
        void AddHotel(Hotel hotel);
        void UpdateHotel(Hotel hotel);
        void DeleteHotel(int id);
    }

}
