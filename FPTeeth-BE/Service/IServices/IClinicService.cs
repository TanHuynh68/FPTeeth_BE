using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Service.IServices
{
    public interface IClinicService
    {
        Task<List<Clinics>> GetClinicsActiveAndDeactive();

        Task<List<Clinics>> GetClinicsPending();

        Task<Clinics?> GetClinicsByName(string name);

        Task DeletePendingClinicById(int id);

        Task<Clinics> UpdateClinicStatusBetweenActiveAndDeactive(int id);

        Task<Clinics> UpdateClinicStatusPendingToActive(int id);
    }
}
