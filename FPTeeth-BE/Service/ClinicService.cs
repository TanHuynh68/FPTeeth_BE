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

        public async Task DeletePendingClinicById(int id)
        {
            var clinic = await _clinicRepository.Get().Where(x => x.Id == id).SingleOrDefaultAsync() ?? throw new Exception("Clinic not found!");
            if (clinic.Status != (int) UserStatusEnum.Pending) { throw new Exception("Clinic is not pending status!"); }
            _clinicRepository.Delete(clinic);
            await _clinicRepository.SaveChangesAsync();
        }

        public async Task<List<Clinics>> GetClinicsActiveAndDeactive()
        {
            return await _clinicRepository.Get().Include(x => x.Owner).Where(x => x.Status == 2 || x.Status == 3).ToListAsync();
        }

        public async Task<Clinics?> GetClinicsByName(string name)
        {
            return await _clinicRepository.Get().Include(x => x.Owner).Where(x => x.Name.Contains(name)).FirstOrDefaultAsync();
        }

        public async Task<List<Clinics>> GetClinicsPending()
        {
            return await _clinicRepository.Get().Include(x => x.Owner).Where(x => x.Status == 1).ToListAsync();
        }
        public async Task<List<Clinics>> GetAllClinicAvailable()
        {
            List<Clinics> result = await _clinicRepository.Get().Include(x => x.Owner).Where(x => x.Status == 2).ToListAsync();
            foreach (Clinics clinic in result)
            {
                clinic.Doctors = await _doctorService.GetAllDoctorByClinicId(clinic.Id);
            }
            return result;
        }

        public async Task<Clinics> GetClinicById(int id)
        {
            Clinics clinic = await _clinicRepository.Get().Include(x => x.Owner).Where(x => x.Id == id).FirstAsync();
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

        public async Task<Clinics> UpdateClinicStatusBetweenActiveAndDeactive(int id)
        {
            var clinic = await _clinicRepository.Get().Where(x => x.Id == id && x.Status != (int)UserStatusEnum.Pending).FirstOrDefaultAsync() ?? throw new Exception("Clinic not found!");
            if(clinic.Status == (int)ClinicStatusEnum.Available)
            {
                clinic.Status = (int)ClinicStatusEnum.Unavailable;
            }else
            {
                clinic.Status = (int)ClinicStatusEnum.Available;
            }
            await _clinicRepository.SaveChangesAsync();
            return clinic;
        }

        public async Task<Clinics> UpdateClinicStatusPendingToActive(int id)
        {
            var clinic = await _clinicRepository.Get().Where(x => x.Id == id && x.Status == (int)UserStatusEnum.Pending).FirstOrDefaultAsync() ?? throw new Exception("Clinic not found!");
            clinic.Status = (int)ClinicStatusEnum.Available;
            await _clinicRepository.SaveChangesAsync();
            return clinic;
        }

        public async Task<List<Clinics>> GetClinicsByOwnerId(int id)
        {
            var result = await _clinicRepository.Get().Include(x => x.Owner).Where(x => x.Owner.Id == id).ToListAsync();
            foreach (var clinic in result)
            {
                clinic.Doctors = await _doctorService.GetAllDoctorByClinicId(clinic.Id);
            }
            return result;
        }

        public async Task UpdateClinicInfo(Clinics clinic)
        {
            var newClinic = await GetClinicById(clinic.Id);
            if (newClinic == null) throw new Exception("Can't find this clinic");
            newClinic.Description = clinic.Description;
            newClinic.Name = clinic.Name;
            newClinic.Address = clinic.Address;
            newClinic.Image = clinic.Image;
            newClinic.UpdateAt = DateTime.Now;
            _clinicRepository.SaveChangesAsync();
        }
    }
}
