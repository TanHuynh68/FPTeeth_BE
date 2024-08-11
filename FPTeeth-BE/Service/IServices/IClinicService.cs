using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Service.IServices
{
    public interface IClinicService
    {
        Task<List<Clinics>> GetClinicsActiveAndDeactive();

        Task<List<Clinics>> GetClinicsPending();
        Task<List<Clinics>> GetAllClinicAvailable();
        Task<Clinics> GetClinicById(int id);
        Task AddNewClinic(AddClinicDto clinic);
    }
}
