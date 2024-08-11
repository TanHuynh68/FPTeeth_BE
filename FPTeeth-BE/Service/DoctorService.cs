using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;
using FPTeeth_BE.Repositories;
using FPTeeth_BE.Service.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FPTeeth_BE.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<Doctor> _doctorRepository;
        private readonly IAccountService _accountService;

        public DoctorService(IRepository<Doctor> doctorRepository, IAccountService accountService)
        {
            _doctorRepository = doctorRepository;
            _accountService = accountService;
        }

        public async Task AddDoctor(Doctor doctor)
        {
            
        }

        public async Task AddDoctorToClinic(int DoctorId, int ClinicId)
        {
            Doctor doctor = await GetDoctorById(DoctorId);
            if (doctor != null)
            {
                doctor.ClinicsId = ClinicId;
                _doctorRepository.Update(doctor);
                await _doctorRepository.SaveChangesAsync();
            }
        }

        public async Task<List<Doctor>> GetAllDoctorByClinicId(int id)
        {
            return await _doctorRepository.Get().Where(x => x.ClinicsId == id).ToListAsync();
        }
        
        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _doctorRepository.Get().Where(x => x.Id == id).FirstAsync();
        }
    }
}
