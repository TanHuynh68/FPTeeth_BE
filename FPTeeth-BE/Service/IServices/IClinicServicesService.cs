using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Service.IServices
{
    public interface IClinicServicesService
    {
        Task<List<Enity.ClinicService>> getAllServiceOfClinic(int id);
        Task addServicesToClinic(int clinicId, int serviceId);
    }
}
