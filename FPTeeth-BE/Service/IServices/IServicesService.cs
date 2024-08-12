using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Service.IServices
{
    public interface IServicesService
    {
        Task<List<Services>> GetAllServices();
        Task<Services> GetServiceById(int id);
        Task ChangeServiceStatus(int id);
    }
}
