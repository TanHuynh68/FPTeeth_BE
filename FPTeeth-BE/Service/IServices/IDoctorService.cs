using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Service.IServices
{
    public interface IDoctorService
    {
        Task<List<DoctorDto>> GetAllDoctorDtoByClinicId(int id);
        Task<List<Doctor>> GetAllDoctorByClinicId(int id);
    }
}
