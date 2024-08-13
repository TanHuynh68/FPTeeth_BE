using FPTeeth_BE.Repositories;
using FPTeeth_BE.Enity;
using FPTeeth_BE.Service.IServices;
using Microsoft.EntityFrameworkCore;

namespace FPTeeth_BE.Service
{
    public class ServicesService : IServicesService
    {
        private readonly IRepository<Services> _servicesRepository;

        public ServicesService(IRepository<Services> servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }

        public async Task ChangeServiceStatus(int id)
        {
            var service = await _servicesRepository.Get().Where(x => x.Id == id).FirstAsync();
            if (service != null)
            {
                if (service.Status == 1) service.Status = 2;
                else service.Status = 1;
            }
            await _servicesRepository.SaveChangesAsync();
        } 

        public async Task<List<Services>> GetAllServices()
        {
            return await _servicesRepository.Get().Where(x => x.Status == 2).ToListAsync();
        }

        public async Task<Services> GetServiceById(int id)
        {
            return await _servicesRepository.Get().Where(x => x.Id == id).FirstAsync();
        }
    }
}
