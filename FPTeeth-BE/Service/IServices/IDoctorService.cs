using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Service.IServices
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAllDoctorByClinicId(int id);
        Task AddDoctorToClinic(int DoctorId, int ClinicId);
        Task AddDoctor(Doctor doctor);
    }
}
