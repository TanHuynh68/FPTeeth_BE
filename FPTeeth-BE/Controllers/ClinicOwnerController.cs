﻿using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;
using FPTeeth_BE.Service.IServices;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ICustomerService _customerService;
        private readonly IBookingService _bookingService;
        private readonly IWorkingTimeService _workingTimeService;

        public ClinicOwnerController(IDoctorService doctorService, IClinicService clinicService, IClinicServicesService clinicServicesService, IServicesService servicesService, IAccountService accountService, ICustomerService customerService, IBookingService bookingService, IWorkingTimeService workingTimeService)
        {
            _doctorService = doctorService;
            _clinicService = clinicService;
            _clinicServicesService = clinicServicesService;
            _servicesService = servicesService;
            _accountService = accountService;
            _customerService = customerService;
            _bookingService = bookingService;
            _workingTimeService = workingTimeService;
        }

        [Authorize(Roles = "CLINICOWNER")]
        [HttpPost("addClinic")]
        public async Task<IActionResult> AddClinic([FromBody] AddClinicDto addClinicDto)
        {
            await _clinicService.AddNewClinic(addClinicDto);
            return Ok();
        }

        [Authorize(Roles = "CLINICOWNER")]
        [HttpPost("addDoctor")]
        public async Task<IActionResult> AddDoctor([FromBody] AddDoctorDto addDoctorDto)
        {
            await _doctorService.AddDoctor(addDoctorDto);
            return Ok();
        }

        [Authorize(Roles = "CLINICOWNER")]
        [HttpPost("addDoctorToClinic")]
        public async Task<IActionResult> AddDoctorToClinic(int doctorId, int clinicId)
        {
            await _doctorService.AddDoctorToClinic(doctorId,clinicId);
            return Ok();
        }

        [Authorize(Roles = "CLINICOWNER")]
        [HttpPost("ChangeClinicStatus")]
        public async Task<IActionResult> ChangeClinicStatus(int clinicId)
        {
            await _clinicService.UpdateClinicStatusBetweenActiveAndDeactive(clinicId);
            return Ok();
        }

        [Authorize(Roles = "CLINICOWNER")]
        [HttpGet("GetAllClinicsByOwnerId")]
        public async Task<List<Clinics>> GetAllClinicsByOwnerId(int ownerId)
        {

            return await _clinicService.GetClinicsByOwnerId(ownerId);
        }

        [Authorize(Roles = "CLINICOWNER")]
        [HttpGet("GetAllPatientsOfClinic")]
        public async Task<List<Customer>> GetAllPatientOfClinic(int clinicId)
        {

            return await _customerService.getAllPatientOfClinic(clinicId);
        }

        [Authorize(Roles = "CLINICOWNER")]
        [HttpGet("GetAllDoctorsOfClinic")]
        public async Task<List<Doctor>> GetAllDoctorByClinicId(int clinicId)
        {

            return await _doctorService.GetAllDoctorByClinicId(clinicId);
        }

        [Authorize(Roles = "CLINICOWNER")]
        [HttpGet("GetAllBookingOfClinic")]
        public async Task<List<Booking>> GetAllBookingOfClinic(int clinicId)
        {

            return await _bookingService.GetAllByClinicId(clinicId);
        }
        
        [Authorize(Roles = "CLINICOWNER")]
        [HttpGet("GetAllWorkingTimeOfDoctor")]
        public async Task<List<WorkingTime>> GetAllWorkingTimeOfDoctor(int doctorId)
        {

            return await _workingTimeService.GetWorkingTimeByDoctorId(doctorId);
        }

        [Authorize(Roles = "CLINICOWNER")]
        [HttpPost("UpdateClinicInformation")]
        public async Task<IActionResult> UpdateClinicInformation([FromBody]Clinics clinic)
        {
            await _clinicService.UpdateClinicInfo(clinic);
            return Ok();
        }

        [Authorize(Roles = "CLINICOWNER")]
        [HttpPost("AddServiceIntoClinic")]
        public async Task<IActionResult> AddServiceIntoClinic(int clinicId,int serviceId)
        {
            await _clinicServicesService.addServicesToClinic(clinicId,serviceId);
            return Ok();
        }
    }
}
