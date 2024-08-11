using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;
using FPTeeth_BE.Enum;
using FPTeeth_BE.Repositories;
using FPTeeth_BE.Service.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FPTeeth_BE.Service
{
    public class ClinicService : IClinicService
    {
        private readonly IRepository<Clinics> _clinicRepository;
        private readonly IDoctorService _doctorService;
        private readonly IAccountService _accountService;

        public ClinicService(IRepository<Clinics> clinicRepository, IDoctorService doctorService, IAccountService accountService)
        {
            _clinicRepository = clinicRepository;
            _doctorService = doctorService;
            _accountService = accountService;
        }

        public async Task<List<Clinics>> GetClinicsActiveAndDeactive()
        {
            return await _clinicRepository.Get().Where(x => x.Status == 2 || x.Status == 3).ToListAsync();
        }

        public async Task<List<Clinics>> GetClinicsPending()
        {
            return await _clinicRepository.Get().Where(x => x.Status == 1).ToListAsync();
        }
        public async Task<List<Clinics>> GetAllClinicAvailable()
        {
            List<Clinics> result = await _clinicRepository.Get().Where(x => x.Status == 2).ToListAsync();
            foreach (Clinics clinic in result)
            {
                clinic.Owner = await _accountService.GetAccountById(clinic.Id);
                clinic.Doctors = await _doctorService.GetAllDoctorByClinicId(clinic.Id);
            }
            return result;
        }

        public async Task<Clinics> GetClinicById(int id)
        {
            Clinics clinic = await _clinicRepository.GetAsync(id);
            clinic.Doctors = await _doctorService.GetAllDoctorByClinicId(id);
            return clinic;
        }

        public async Task AddNewClinic(AddClinicDto clinic)
        {
            var newClinic = new Clinics
            {
                Address = clinic.Address,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Description = clinic.Description,
                Image = clinic.Image,
                Name = clinic.Name,
                Status = (int)ClinicStatusEnum.Pending,
                Owner = await _accountService.GetAccountById(clinic.OwnerId),
                Doctors = null,
            };
            await _clinicRepository.AddAsync(newClinic);
            await _clinicRepository.SaveChangesAsync();
        }
    }
}
