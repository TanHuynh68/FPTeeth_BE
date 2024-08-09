using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;
using FPTeeth_BE.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FPTeeth_BE.Controllers
{
    [ApiController]
    [Route("Admin")]
    [EnableCors]
    public class AdminController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IClinicService _clinicService;

        public AdminController(IAccountService accountService, IClinicService clinicService)
        {
            _accountService = accountService;
            _clinicService = clinicService;
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost("addClinicOwner")]
        public async Task<IActionResult> AddClinicOwner([FromBody] AddClinicOnwerDto addClinicOnwerDto) {
            await _accountService.AddClinicOwner(addClinicOnwerDto);
            return Ok();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("getListUserActiveAndDeactive")]
        public async Task<List<Account>> GetListUserActiveAndDeactive()
        {
            
            return await _accountService.GetListUserActiveAndDeactive();
        }
        [Authorize(Roles = "ADMIN")]
        [HttpGet("getListUserPending")]
        public async Task<List<Account>> GetListUserPending()
        {

            return await _accountService.GetListUserPending();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("getListClinicActiveAndDeactive")]
        public async Task<List<Clinics>> GetListClinicActiveAndDeactive()
        {

            return await _clinicService.GetClinicsActiveAndDeactive();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("getClinicsPending")]
        public async Task<List<Clinics>> GetClinicsPending()
        {
            return await _clinicService.GetClinicsPending();
        }
    }
}
