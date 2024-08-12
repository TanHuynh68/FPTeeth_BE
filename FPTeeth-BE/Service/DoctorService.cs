using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;
using FPTeeth_BE.Enum;
using FPTeeth_BE.Repositories;
using FPTeeth_BE.Service.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Collections.Generic;

namespace FPTeeth_BE.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<Doctor> _doctorRepository;
        private readonly IAccountService _accountService;
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Role> _roleRepository;

        public DoctorService(IRepository<Doctor> doctorRepository, IAccountService accountService, IRepository<Account> accountRepository, IRepository<Role> roleRepository)
        {
            _doctorRepository = doctorRepository;
            _accountService = accountService;
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
        }

        public async Task AddDoctor(AddDoctorDto doctor)
        {
            var user = await _accountRepository.Get().Where(x => x.Email == doctor.Email).FirstAsync();
            if (user != null) throw new Exception("Duplicate email!");
            var newAcc = new Account
            {
                CreatedAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Email = doctor.Email,
                FullName = doctor.Name,
                Gender = doctor.Gender,
                Password = doctor.Password,
                Role = await _roleRepository.Get().Where(x => x.Name == "DOCTOR").FirstAsync(),
                Status = (int)UserStatusEnum.Active,
            };
            await _accountRepository.AddAsync(newAcc);
            await _accountRepository.SaveChangesAsync();
            var newDoc = new Doctor
                {
                    Account = newAcc,
            };
            await _doctorRepository.AddAsync(newDoc);
            await _roleRepository.SaveChangesAsync();
        }

        public async Task AddDoctorToClinic(int DoctorId, int ClinicId)
        {
            Doctor doctor = await GetDoctorById(DoctorId);
            if (doctor != null)
            {
                doctor.ClinicsId = ClinicId;
                await _doctorRepository.SaveChangesAsync();
            }
        }

        public async Task<List<Doctor>> GetAllDoctorByClinicId(int id)
        {
            return await _doctorRepository.Get().Where(x => x.ClinicsId == id).ToListAsync();
        }
        
        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _doctorRepository.Get().Where(x => x.Account.Id == id).FirstAsync();
        }
    }
}
