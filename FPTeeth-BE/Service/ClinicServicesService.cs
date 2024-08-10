using FPTeeth_BE.Enity;
using FPTeeth_BE.Repositories;
using FPTeeth_BE.Service.IServices;
using Microsoft.EntityFrameworkCore;

namespace FPTeeth_BE.Service
{
    public class ClinicServicesService : IClinicServicesService
    {
        private readonly IRepository<Enity.ClinicService> _clinicServiceRepository;

        public async Task<List<FPTeeth_BE.Enity.ClinicService>> GetAllServiceOfClinic(int id)
        {
            return await _clinicServiceRepository.Get().Where(x => x.Clinics.Id == id).ToListAsync();
        }
    }
}
