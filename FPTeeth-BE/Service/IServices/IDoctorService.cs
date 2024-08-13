using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Service.IServices
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAllDoctor();
        Task<List<Doctor>> GetAllDoctorByClinicId(int id);
        Task AddDoctorToClinic(int doctorId, int clinicId);
        Task AddDoctor(AddDoctorDto doctor);
    }
}
