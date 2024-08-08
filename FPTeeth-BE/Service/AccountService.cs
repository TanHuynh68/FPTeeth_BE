using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;
using FPTeeth_BE.Repositories;
using FPTeeth_BE.Service.IServices;
using Microsoft.EntityFrameworkCore;

namespace FPTeeth_BE.Service
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Role> _roleRepository;

        public AccountService(IRepository<Account> accountRepository, IRepository<Role> roleRepository)
        {
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
        }

        public async Task AddClinicOwner(AddClinicOnwerDto addClinicOnwerDto)
        {
            var newOnwer = new Account
            {
                CreatedAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                UserName = addClinicOnwerDto.UserName,
                Password = addClinicOnwerDto.Password,
                Status = 2,
                Role = await _roleRepository.Get().Where(x => x.Name == "CLINICOWNER").FirstAsync()
            };

            await _accountRepository.AddAsync(newOnwer);
            await _accountRepository.SaveChangesAsync();
        }

        public async Task<List<Account>> GetListUserActiveAndDeactive()
        {
            return await _accountRepository.Get().Include(x => x.Role).Where(x => x.Status == 2 || x.Status == 3).ToListAsync();
        }

        public async Task<List<Account>> GetListUserPending()
        {
            return await _accountRepository.Get().Include(x => x.Role).Where(x => x.Status == 1).ToListAsync();
        }
    }
}
