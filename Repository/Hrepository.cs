using Hotel_Booking.Model;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace Hotel_Booking.Repository
{
    public class Hrepository : IHrepository
    {
        private readonly HotelDbContext _dbContext;

        public Hrepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddHotel(Hotel hotel)
        {
            _dbContext.Set<Hotel>().Add(hotel);
            _dbContext.SaveChanges();
        }

        public void DeleteHotel(int id)
        {
            var hotel = _dbContext.Set<Hotel>().Find(id);
            _dbContext.Set<Hotel>().Remove(hotel);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return _dbContext.Set<Hotel>().ToList();
        }

        public Hotel GetHotelById(int id)
        {
            return _dbContext.Set<Hotel>().Find(id);
        }

        public void UpdateHotel(Hotel hotel)
        {
            _dbContext.Entry(hotel).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
