using FPTeeth_BE.Dtos;
using FPTeeth_BE.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FPTeeth_BE.Controllers
{
    [ApiController]
    [Route("ClinicOwner")]
    public class ClinicOwnerController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IClinicService _clinicService;
        private readonly IClinicServicesService _clinicServicesService;
        private readonly IServicesService _servicesService;
        private readonly IAccountService _accountService;

        public ClinicOwnerController(IDoctorService doctorService, IClinicService clinicService, IClinicServicesService clinicServicesService, IServicesService servicesService, IAccountService accountService)
        {
            _doctorService = doctorService;
            _clinicService = clinicService;
            _clinicServicesService = clinicServicesService;
            _servicesService = servicesService;
            _accountService = accountService;
        }

        [HttpPost("addClinic")]
        public async Task<IActionResult> AddClinic([FromBody] AddClinicDto addClinicDto)
        {
            await _clinicService.AddNewClinic(addClinicDto);
            return Ok();
        }
    }
}
