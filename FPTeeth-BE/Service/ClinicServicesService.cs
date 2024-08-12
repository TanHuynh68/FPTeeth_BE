using FPTeeth_BE.Enity;
using FPTeeth_BE.Repositories;
using FPTeeth_BE.Service.IServices;
using Microsoft.EntityFrameworkCore;

namespace FPTeeth_BE.Service
{
    public class ClinicServicesService : IClinicServicesService
    {
        private readonly IRepository<Enity.ClinicService> _clinicServiceRepository;
        private readonly IServicesService _servicesService;
        private readonly IClinicService _clinicService;
        public ClinicServicesService(IRepository<Enity.ClinicService> clinicServiceRepository, IServicesService servicesService, IClinicService clinicService)
        {
            _clinicServiceRepository = clinicServiceRepository;
            _servicesService = servicesService;
            _clinicService = clinicService;
        }

        public async Task addServicesToClinic(int clinicId, int serviceId)
        {
            var clinic = await _clinicService.GetClinicById(clinicId);
            var service = await _servicesService.GetServiceById(serviceId);
            if (service != null && clinic != null)
            {
                var clinicService = new FPTeeth_BE.Enity.ClinicService
                {
                    Clinics = clinic,
                    Services = service,
                };
                await _clinicServiceRepository.AddAsync(clinicService);
                await _clinicServiceRepository.SaveChangesAsync();
            }
        }

        public Task<List<Enity.ClinicService>> getAllServiceOfClinic(int id)
        {
            return _clinicServiceRepository.Get().ToListAsync();
        }
    }
}
