using FPTeeth_BE.Enity;
using FPTeeth_BE.Repositories;
using FPTeeth_BE.Service.IServices;
using Microsoft.EntityFrameworkCore;

namespace FPTeeth_BE.Service
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<Booking> _bookingRepository;
        public BookingService(IRepository<Booking> bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<List<Booking>> GetAllByPatientId(int patientId)
        {
            var booking = await _bookingRepository.Get().Where(x => x.customer.Id == patientId).ToListAsync();
            if (booking.Count() == 0)
            {
                return null;
            }
            return booking;
        }

        public async Task<Booking> UpdateResult(int id, string result)
        {
            var booking = await _bookingRepository.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (booking == null)
            {
                return null;
            }

            booking.Result = result;
            _bookingRepository.Update(booking);
            await _bookingRepository.SaveChangesAsync();

            return booking;
        }
    }
}
