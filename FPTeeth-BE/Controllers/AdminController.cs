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
        public async Task<IActionResult> AddClinicOwner([FromBody] AddClinicOwnerDto addClinicOwnerDto) {
            await _accountService.AddClinicOwner(addClinicOwnerDto);
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
        [HttpPut("updateStatusBetweenActiveAnDeactive/{id}")]
        public async Task<Account> UpdateStatusBetweenActiveAnDeactive(int id)
        {

            return await _accountService.UpdateStatusBetweenActiveAnDeactive(id);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpDelete("deleteUserPendingById/{id}")]
        public async Task<IActionResult> DeleteUserPendingById(int id)
        {
            await _accountService.DeleteUserPendingById(id);
            return Ok();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost("GetAccountByFilter")]
        public async Task<IActionResult> GetAccountByFilter(FilterUserDTO filterUserDTO)
        {
            await _accountService.GetAccountByFilter(filterUserDTO);
            return Ok();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut("updateStatusPendingToActive/{id}")]
        public async Task<Account> UpdateStatusPendingToActive(int id)
        {

            return await _accountService.UpdateStatusPendingToActive(id);
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

        [Authorize(Roles = "ADMIN")]
        [HttpGet("getClinicsByName/{name}")]
        public async Task<Clinics?> GetClinicsByName(string name)
        {
            return await _clinicService.GetClinicsByName(name);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpDelete("deletePendingClinicById/{id}")]
        public async Task<IActionResult> DeletePendingClinicById(int id)
        {
            await _clinicService.DeletePendingClinicById(id);
            return Ok();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut("UpdateClinicStatusPendingToActive/{id}")]
        public async Task<IActionResult> UpdateClinicStatusPendingToActive(int id)
        {
            await _clinicService.UpdateClinicStatusPendingToActive(id);
            return Ok();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut("UpdateClinicStatusBetweenActiveAndDeactive/{id}")]
        public async Task<IActionResult> UpdateClinicStatusBetweenActiveAndDeactive(int id)
        {
            await _clinicService.UpdateClinicStatusBetweenActiveAndDeactive(id);
            return Ok();
        }


    }
}
