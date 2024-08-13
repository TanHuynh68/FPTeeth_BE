using FPTeeth_BE.Enity;
using FPTeeth_BE.Repositories;
using FPTeeth_BE.Service.IServices;
using Microsoft.EntityFrameworkCore;

namespace FPTeeth_BE.Service
{
    public class WorkingTimeService : IWorkingTimeService
    {
        private readonly IRepository<WorkingTime> _workingTimeRepository;

        public WorkingTimeService(IRepository<WorkingTime> workingTimeRepository)
        {
            _workingTimeRepository = workingTimeRepository;
        }

        public async Task<List<WorkingTime>> GetAllWorkingTime()
        {
            return await _workingTimeRepository.Get().Include(x => x.Doctor).Include(x => x.Slot).ToListAsync();
        }

        public async Task<List<WorkingTime>> GetWorkingTimeByDoctorId(int id)
        {
            var response = await _workingTimeRepository.Get().Include(x => x.Doctor).Include(x => x.Slot).Where(x => x.Doctor.Id == id).ToListAsync();
            return response;
        }
    }
}
