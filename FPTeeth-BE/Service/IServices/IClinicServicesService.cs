using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Service.IServices
{
    public interface IClinicServicesService
    {
        Task<List<FPTeeth_BE.Enity.ClinicService>> GetAllServiceOfClinic(int id);
    }
}
