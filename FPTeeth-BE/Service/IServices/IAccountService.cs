using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Service.IServices
{
    public interface IAccountService
    {
        Task AddClinicOwner(AddClinicOwnerDto addClinicOwnerDto);
        Task<List<Account>> GetListUserActiveAndDeactive();
        Task<List<Account>> GetListUserPending();
        Task<Account> GetAccountById(int id);
        Task<Account?> Login(LoginDto loginDto);
        Task<Account> Register(RegisterDto registerDto);
        Task<Account> UpdateStatusBetweenActiveAnDeactive(int id);
        Task<Account> UpdateStatusPendingToActive(int id);
        Task DeleteUserPendingById(int id);
        Task<List<Account>> GetAccountByFilter(FilterUserDTO filterUserDTO);
    }
}
