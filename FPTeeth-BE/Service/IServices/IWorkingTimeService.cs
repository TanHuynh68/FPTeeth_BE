using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Service.IServices
{
    public interface IWorkingTimeService
    {
        Task<List<WorkingTime>> GetAllWorkingTime();
        Task<List<WorkingTime>> GetWorkingTimeByDoctorId(int id);
    }
}
