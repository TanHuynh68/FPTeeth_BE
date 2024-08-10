using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Service.IServices
{
    public interface IServicesService
    {
        Task<List<Services>> GetAllServices();
        Task ChangeServiceStatus(int id);
    }
}
