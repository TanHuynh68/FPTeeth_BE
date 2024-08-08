using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Service.IServices
{
    public interface IClinicService
    {
        Task<List<Clinics>> GetClinicsActiveAndDeactive();

        Task<List<Clinics>> GetClinicsPending();
    }
}
