using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;
using FPTeeth_BE.Enum;
using FPTeeth_BE.Extension;
using FPTeeth_BE.Repositories;
using FPTeeth_BE.Service.IServices;
using Microsoft.EntityFrameworkCore;

namespace FPTeeth_BE.Service
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly JwtHelper _jwtHelper;
        private readonly IRepository<Role> _roleRepository;

        public AccountService(IRepository<Account> accountRepository,
            JwtHelper jwtHelper, IRepository<Role> roleRepository, IRepository<Customer> customerRepository)
        {
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
            _jwtHelper = jwtHelper;
            _customerRepository = customerRepository;
        }

        public async Task AddClinicOwner(AddClinicOwnerDto addClinicOwnerDto)
        {
            var email = await _accountRepository.Get().Where(x => x.Email == addClinicOwnerDto.Email).SingleOrDefaultAsync();

            if (email != null) throw new Exception("Duplicate email!");

            var newOwner = new Account
            {
                CreatedAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                FullName = addClinicOwnerDto.FullName,
                Gender = addClinicOwnerDto.Gender,
                Email = addClinicOwnerDto.Email,
                Password = addClinicOwnerDto.Password,
                Status = (int) UserStatusEnum.Active,
                Role = await _roleRepository.Get().Where(x => x.Name == "CLINICOWNER").FirstAsync()
            };

            await _accountRepository.AddAsync(newOwner);
            await _accountRepository.SaveChangesAsync();
        }

        public async Task<List<Account>> GetListUserActiveAndDeactive()
        {
            return await _accountRepository.Get().Include(x => x.Role).Where(x => x.Status == 2 || x.Status == 3).ToListAsync();
        }
        public async Task<List<Account>> GetAllDoctor()
        {
            return await _accountRepository.Get().Where(x => x.Role.Id == 3).Where(x => x.Status == 2).ToListAsync();
        }

        public async Task<List<Account>> GetListUserPending()
        {
            return await _accountRepository.Get().Include(x => x.Role).Where(x => x.Status == 1).ToListAsync();
        }

        public async Task<Account> GetAccountById(int id)
        {
            return await _accountRepository.GetAsync(id);
        }

        public async Task<Account?> Login(LoginDto loginDto)
        {
            return await _accountRepository.Get().Include(x => x.Role).Where(x => x.Email == loginDto.Email && x.Password == loginDto.Password).FirstOrDefaultAsync();

        }

        public async Task<Account> Register(RegisterDto registerDto)
        {
            var email = await _accountRepository.Get().Where(x => x.Email == registerDto.Email).SingleOrDefaultAsync();

            if (email != null) throw new Exception("Duplicate email!");

            var newCus
                = new Account
                {
                    CreatedAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Email = registerDto.Email,
                    Password = registerDto.Password,
                    Status = (int)UserStatusEnum.Active,
                    Role = await _roleRepository.Get().Where(x => x.Name == "CUSTOMER").FirstAsync()
                };

            await _accountRepository.AddAsync(newCus);
            await _accountRepository.SaveChangesAsync();

            return newCus;
        }

        public async Task<Account> UpdateStatusBetweenActiveAnDeactive(int id)
        {
            var user = await _accountRepository.Get().Where(x => x.Id == id && x.Role.Name != "ADMIN" && x.Status != (int)UserStatusEnum.Pending).SingleOrDefaultAsync() ?? throw new Exception("User not found!");
            if (user.Status == (int)UserStatusEnum.Active)
            {
                user.Status = (int)UserStatusEnum.Deactive;
            }
            else
            {
                user.Status = (int)UserStatusEnum.Active;
            }

            await _accountRepository.SaveChangesAsync();

            return user;
        }

        public async Task<Account> UpdateStatusPendingToActive(int id)
        {
            var user = await _accountRepository.Get()
                        .Where(x => x.Id == id &&
                               x.Role.Name != "ADMIN" &&
                               x.Status == (int)UserStatusEnum.Pending)
                .SingleOrDefaultAsync() ?? throw new Exception("User not found!");

            user.Status = (int)UserStatusEnum.Active;

            await _accountRepository.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserPendingById(int id)
        {
            var user = await _accountRepository.Get().Where(x => x.Id == id && x.Status == (int)UserStatusEnum.Pending).SingleOrDefaultAsync() ?? throw new Exception("User not found!");
            _accountRepository.Delete(user);
            await _accountRepository.SaveChangesAsync();
        }

        public async Task<List<Account>> GetAccountByFilter(FilterUserDTO filterUserDTO)
        {
            var query = _accountRepository.Get();
            if (!string.IsNullOrEmpty(filterUserDTO.Name))
            {
                query = query.Where(x => x.FullName.Contains(filterUserDTO.Name));
            }
            if (!string.IsNullOrEmpty(filterUserDTO.RoleName))
            {
                query = query.Where(x => x.Role.Name == filterUserDTO.RoleName);
            }

            return await query.ToListAsync();
        }
    }
}
