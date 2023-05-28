using Hotel_Booking.Model;

namespace Hotel_Booking.Repository
{
    public interface IFilter
    {
        IEnumerable<Hotel> GetFilteredHotels(string? location, decimal? minPrice, decimal? maxPrice);
        int Results(int id);
    }
}
