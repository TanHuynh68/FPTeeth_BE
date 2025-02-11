using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Service.IServices
{
    public interface IBookingService
    {

        Task<Booking> UpdateResult(int id, string result);
        Task<List<Booking>> GetAllByPatientId(int patientId);
        Task<List<Booking>> GetAllByClinicId(int clinicId);
        Task<Booking> AddBooking(BookingDto booking);
    }
}
