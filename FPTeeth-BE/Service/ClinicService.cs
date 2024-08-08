using FPTeeth_BE.Enity;
using FPTeeth_BE.Repositories;
using FPTeeth_BE.Service.IServices;
using Microsoft.EntityFrameworkCore;

namespace FPTeeth_BE.Service
{
    public class ClinicService : IClinicService
    {
        private readonly IRepository<Clinics> _clinicRepository;

        public ClinicService(IRepository<Clinics> clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        public async Task<List<Clinics>> GetClinicsActiveAndDeactive()
        {
            return await _clinicRepository.Get().Where(x => x.Status == 2 || x.Status == 3).ToListAsync();
        }

        public async Task<List<Clinics>> GetClinicsPending()
        {
            return await _clinicRepository.Get().Where(x => x.Status == 1).ToListAsync();
        }
    }
}
