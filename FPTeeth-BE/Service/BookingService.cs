using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;
using FPTeeth_BE.Enum;
using FPTeeth_BE.Repositories;
using FPTeeth_BE.Service.IServices;
using Microsoft.EntityFrameworkCore;

namespace FPTeeth_BE.Service
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<Clinics> _clinicRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Doctor> _doctorRepository;
        private readonly IRepository<FPTeeth_BE.Enity.ClinicService> _clinicServiceRepository;
        private readonly IRepository<Medicine> _medicineRepository;
        private readonly IRepository<Slot> _slotRepository;

        public BookingService(IRepository<Booking> bookingRepository,
                            IRepository<Clinics> clinicRepository,
                            IRepository<Customer> customerRepository,
                            IRepository<Doctor> doctorRepository,
                            IRepository<FPTeeth_BE.Enity.ClinicService> clinicServiceRepository,
                            IRepository<Medicine> medicineRepository,
                            IRepository<Slot> slotRepository
                            )
        {
            _bookingRepository = bookingRepository;
            _clinicRepository = clinicRepository;
            _customerRepository = customerRepository;
            _doctorRepository = doctorRepository;
            _clinicServiceRepository = clinicServiceRepository;
            _slotRepository = slotRepository;
            _medicineRepository = medicineRepository;
        }

        public async Task<List<Booking>> GetAllByPatientId(int patientId)
        {
            var result = await _bookingRepository.Get().Include(x => x.Customer).Include(x => x.Doctor).Include(x => x.ClinicsService).Include(x => x.Medicines).Where(x => x.Customer.Id == patientId).ToListAsync();
            return result;
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

        public async Task<Booking> AddBooking(BookingDto bookingDto)
        {
            var clinic = await _clinicRepository.Get().Where(x => x.Id == bookingDto.ClinicId).SingleOrDefaultAsync();
            var customer = await _customerRepository.Get().Where(x => x.Account.Id == bookingDto.CustomerId).SingleOrDefaultAsync();
            var doctor = await _doctorRepository.Get().Where(x => x.Account.Id == bookingDto.DoctorID).SingleOrDefaultAsync();
            var clinicService = await _clinicServiceRepository.Get().Where(x => x.Clinics.Id == bookingDto.ClinicId && x.Services.Id == bookingDto.ServiceId).FirstOrDefaultAsync();
            var slot = await _slotRepository.Get().Where(x => x.SlotTime == bookingDto.Slot).SingleOrDefaultAsync();
            var newBooking = new Booking
            {
                Customer = customer,
                BookingAddress = clinic.Address,
                ClinicsService = clinicService,
                BookingDate = bookingDto.BookingDate,
                BookingName = clinic.Name,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Doctor = doctor,
                Status = (int)BookingStatusEnum.Booking,
                Type = bookingDto.Type,
                Slot = slot,
            };

            await _bookingRepository.AddAsync(newBooking);
            await _bookingRepository.SaveChangesAsync();
            return newBooking;
        }

        public async Task<List<Booking>> GetAllByClinicId(int clinicId)
        {
            var booking = await _bookingRepository.Get().Include(x => x.Customer).Include(x => x.Doctor).Include(x => x.ClinicsService).Include(x => x.Medicines).Where(x => x.ClinicsService.Clinics.Id == clinicId).ToListAsync();
            return booking;
        }
    }
}