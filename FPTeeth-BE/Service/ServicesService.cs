using FPTeeth_BE.Repositories;
using FPTeeth_BE.Enity;
using FPTeeth_BE.Service.IServices;
using Microsoft.EntityFrameworkCore;

namespace FPTeeth_BE.Service
{
    public class ServicesService : IServicesService
    {
        private readonly IRepository<Services> _servicesRepository;

        public Task ChangeServiceStatus(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Services>> GetAllServices()
        {
            return await _servicesRepository.Get().Where(x => x.Status == 2).ToListAsync();
        }
    }
}
