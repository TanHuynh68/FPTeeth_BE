using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;
using FPTeeth_BE.Extension;
using FPTeeth_BE.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FPTeeth_BE.Controllers
{
    [ApiController]
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly JwtHelper _jwtHelper;
        private readonly IAccountService _accountService;

        public AccountController(JwtHelper jwtHelper, IAccountService accountService)
        {
            _jwtHelper = jwtHelper;
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _accountService.Login(loginDto);

            if (user == null)
            {
                return Unauthorized();
            }
            // Xác thực thông tin người dùng và gán quyền (đây chỉ là một ví dụ đơn giản)
            var token = _jwtHelper.GenerateToken(user);

            return Ok(new { Token = "Bearer " + token });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<Account> Register([FromBody] RegisterDto registerDto)
        {
            var customer = await _accountService.Register(registerDto);
            return customer;
        }
    }
}
