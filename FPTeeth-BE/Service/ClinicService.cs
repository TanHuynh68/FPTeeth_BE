using FPTeeth_BE.Enity;
using FPTeeth_BE.Enum;
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

        public async Task DeletePendingClinicById(int id)
        {
            var clinic = await _clinicRepository.Get().Where(x => x.Id == id).SingleOrDefaultAsync() ?? throw new Exception("Clinic not found");
            if (clinic.Status == (int)UserStatusEnum.Pending) { throw new Exception("Clinic is not Pending status"); }
            _clinicRepository.Delete(clinic);
            await _clinicRepository.SaveChangesAsync();
        }

        public async Task<List<Clinics>> GetClinicsActiveAndDeactive()
        {
            return await _clinicRepository.Get().Where(x => x.Status == 2 || x.Status == 3).ToListAsync();
        }

        public async Task<Clinics?> GetClinicsByName(string name)
        {
            return await _clinicRepository.Get().Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<List<Clinics>> GetClinicsPending()
        {
            return await _clinicRepository.Get().Where(x => x.Status == 1).ToListAsync();
        }

        public async Task<Clinics> UpdateClinicStatusBetweenActiveAndDeactive(int id)
        {
            var clinic = await _clinicRepository.Get().Where(x => x.Id == id && x.Status != (int)UserStatusEnum.Pending).FirstOrDefaultAsync() ?? throw new Exception("Clinic not found");
            if(clinic.Status == (int)UserStatusEnum.Active)
            {
                clinic.Status = (int)UserStatusEnum.Deactive;
            }else
            {
                clinic.Status = (int)UserStatusEnum.Active;
            }
            await _clinicRepository.SaveChangesAsync();
            return clinic;
        }

        public async Task<Clinics> UpdateCliníctatusPendingToActive(int id)
        {
            var clinic = await _clinicRepository.Get().Where(x => x.Id == id && x.Status == (int)UserStatusEnum.Pending).FirstOrDefaultAsync() ?? throw new Exception("Clinic not found");
            clinic.Status = (int)UserStatusEnum.Active;
            await _clinicRepository.SaveChangesAsync();
            return clinic;
        }
    }
}
