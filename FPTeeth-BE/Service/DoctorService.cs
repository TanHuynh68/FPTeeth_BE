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

        public DoctorService(IRepository<Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<List<Doctor>> GetAllDoctorByClinicId(int id)
        {
            return await _doctorRepository.Get().Where(x => x.ClinicsId == id).ToListAsync();
        }

        public async Task<List<DoctorDto>> GetAllDoctorDtoByClinicId(int id)
        {
            List<Doctor> list = await _doctorRepository.Get().Where(x => x.ClinicsId == id).ToListAsync();
            List<DoctorDto> result = new List<DoctorDto>();
            foreach (var doctor in list)
            {
                DoctorDto doctorDto = new DoctorDto
                {
                    Name = doctor.DortorName,
                    Description = "Very gud",
                    Image = "image"
                };
                result.Add(doctorDto);
            }
            return result;
        }
    }
}
