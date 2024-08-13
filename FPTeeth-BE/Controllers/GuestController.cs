using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;
using FPTeeth_BE.Extension;
using FPTeeth_BE.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace FPTeeth_BE.Controllers
{
    [ApiController]
    [Route("Guest")]
    [EnableCors]
    public class GuestController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IClinicService _clinicService;
        private readonly IClinicServicesService _clinicServicesService;
        private readonly IServicesService _servicesService;
        private readonly IAccountService _accountService;

        public GuestController(IDoctorService doctorService, IClinicService clinicService, IClinicServicesService clinicServicesService, IServicesService servicesService, IAccountService accountService)
        {
            _doctorService = doctorService;
            _clinicService = clinicService;
            _clinicServicesService = clinicServicesService;
            _servicesService = servicesService;
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpGet("GetAllDoctors")]
        public async Task<List<Doctor>> GetAllDoctors()
        {
            return await _doctorService.GetAllDoctor();
        }

        [AllowAnonymous]
        [HttpGet("GetAllClinics")]
        public async Task<List<Clinics>> GetAllClinics()
        {
            return await _clinicService.GetAllClinicAvailable();
        }

        [AllowAnonymous]
        [HttpGet("GetAllServices")]
        public async Task<List<Services>> GetAllServices()
        {
            return await _servicesService.GetAllServices();
        }

        [AllowAnonymous]
        [HttpGet("GetAllServicesOfClinic")]
        public async Task<List<ClinicService>> GetAllServicesOfClinic(int id)
        {
            return await _clinicServicesService.getAllServiceOfClinic(id);
        }
    }
}
