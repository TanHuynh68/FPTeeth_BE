using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;
using FPTeeth_BE.Service.IServices;
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

        [HttpPost("addClinicOwner")]
        public async Task<IActionResult> AddClinicOwner([FromBody] AddClinicOnwerDto addClinicOnwerDto) {
            await _accountService.AddClinicOwner(addClinicOnwerDto);
            return Ok();
        }


        [HttpGet("getListUserActiveAndDeactive")]
        public async Task<List<Account>> GetListUserActiveAndDeactive()
        {
            
            return await _accountService.GetListUserActiveAndDeactive();
        }

        [HttpGet("getListUserPending")]
        public async Task<List<Account>> GetListUserPending()
        {

            return await _accountService.GetListUserPending();
        }

        [HttpGet("getListClinicActiveAndDeactive")]
        public async Task<List<Clinics>> GetListClinicActiveAndDeactive()
        {

            return await _clinicService.GetClinicsActiveAndDeactive();
        }

        [HttpGet("getClinicsPending")]
        public async Task<List<Clinics>> GetClinicsPending()
        {

            return await _clinicService.GetClinicsPending();
        }
    }
}
