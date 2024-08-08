using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Service.IServices
{
    public interface IAccountService
    {
        Task AddClinicOwner(AddClinicOnwerDto addClinicOnwerDto);
        Task<List<Account>> GetListUserActiveAndDeactive();
        Task<List<Account>> GetListUserPending();
    }
}
