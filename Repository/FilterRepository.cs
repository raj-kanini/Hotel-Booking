using Hotel_Booking.Model;

namespace Hotel_Booking.Repository
{
    public class FilterRepository : IFilter
    {
        private readonly HotelDbContext _dbContext;

        public FilterRepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Hotel> GetFilteredHotels(string location, decimal? minPrice, decimal? maxPrice)
        {
            var hotels = _dbContext.Set<Hotel>().AsQueryable();
            var rooms = _dbContext.Set<Room>().AsQueryable();

            if (!string.IsNullOrEmpty(location))
                hotels = hotels.Where(h => h.HLocation.Contains(location));

            if (minPrice != null)
                hotels = hotels.Where(h => h.Price >= minPrice);

            if (maxPrice != null)
                hotels = hotels.Where(h => h.Price <= maxPrice);

            return hotels.ToList();
        }

        public int Results(int id)
        {
            Hotel hotel = _dbContext.Hotels.FirstOrDefault(h => h.HId == id);


            int availableRoomsCount = _dbContext.Rooms.Count(r => r.HId == id && r.Availability == true);

            return availableRoomsCount;

        }

    }
}
