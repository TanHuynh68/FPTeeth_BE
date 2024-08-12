using FPTeeth_BE.Enity;
using FPTeeth_BE.Repositories;
using FPTeeth_BE.Service.IServices;
using Microsoft.EntityFrameworkCore;

namespace FPTeeth_BE.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IBookingService _bookingService;

        public CustomerService(IRepository<Customer> customerRepository, IBookingService bookingService)
        {
            _customerRepository = customerRepository;
            _bookingService = bookingService;
        }

        public async Task<List<Customer>> getAllPatientOfClinic(int clinicId)
        {
            List<Booking> list = await _bookingService.GetAllByClinicId(clinicId);
            if (list == null) return null;

            List<Customer> customers = new List<Customer>();
            foreach (Booking booking in list)
            {
                Customer customer = await _customerRepository.Get().Where(x => x.Id == booking.Customer.Id).FirstAsync();
                customers.Add(customer);
            }
            return customers; 
        }
    }
}
