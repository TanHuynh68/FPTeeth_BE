using FPTeeth_BE.Controllers;
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

        public async Task AddClinicOwner(AddClinicOnwerDto addClinicOnwerDto)
        {
            var newOnwer = new Account
            {
                CreatedAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Email = addClinicOnwerDto.UserName,
                Password = addClinicOnwerDto.Password,
                Status = (int)UserStatusEnum.Active,
                Role = await _roleRepository.Get().Where(x => x.Name == "CLINICOWNER").FirstAsync()
            };

            await _accountRepository.AddAsync(newOnwer);
            await _accountRepository.SaveChangesAsync();
        }

        public async Task<List<Account>> GetListUserActiveAndDeactive()
        {
            return await _accountRepository.Get().Include(x => x.Role).Where(x => x.Status == 2 || x.Status == 3).ToListAsync();
        }
        public async Task<List<DoctorDto>> GetAllDoctor()
        {
            List<Account> list = await _accountRepository.Get().Where(x => x.Role.Id == 3).Where(x => x.Status == 2).ToListAsync();
            List<DoctorDto> result = new List<DoctorDto>();
            foreach (var account in list)
            {
                DoctorDto doctor = new DoctorDto
                {
                    Name = "Doctor's name",
                    Description = "Very good",
                    Image = account.Image
                };
                result.Add(doctor);
            };
            return result;
        }

        public async Task<List<Account>> GetListUserPending()
        {
            return await _accountRepository.Get().Include(x => x.Role).Where(x => x.Status == 1).ToListAsync();
        }

        public async Task<Account> GetAccountById(int id)
        {
            return await _accountRepository.Get().Include(x => x.Role).Where(x => x.Id == id).FirstAsync();
        }

        public async Task<Account?> Login(LoginDto loginDto)
        {
            return await _accountRepository.Get().Include(x => x.Role).Where(x => x.Email == loginDto.Email && x.Password == loginDto.Password).FirstOrDefaultAsync();

        }

        public async Task<Customer> Register(RegisterDto registerDto)
        {
            var email = await _accountRepository.Get().Where(x => x.Email == registerDto.Email).SingleOrDefaultAsync();

            if (email != null) throw new Exception("Duplicate Email");

            var newCus = new Customer
            {
                Account = new Account
                {
                    CreatedAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Email = registerDto.Email,
                    Password = registerDto.Password,
                    Status = (int)UserStatusEnum.Active,
                    Role = await _roleRepository.Get().Where(x => x.Name == "CUSTOMER").FirstAsync()
                },
                CustomerName = registerDto.FullName
            };

            await _customerRepository.AddAsync(newCus);
            await _customerRepository.SaveChangesAsync();

            return newCus;
        }
    }
}
