using FPTeeth_BE.Enity;
using FPTeeth_BE.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FPTeeth_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkingTimeController: ControllerBase
    {
        private readonly IWorkingTimeService _workingTimeService;

        public WorkingTimeController(IWorkingTimeService workingTimeService)
        {
            _workingTimeService = workingTimeService;
        }

        [Authorize(Roles = "DOCTOR")]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllWorkingTime()
        {
            return Ok(await _workingTimeService.GetAllWorkingTime());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkingTimeByDoctorId(int id)
        {
            return Ok(await _workingTimeService.GetWorkingTimeByDoctorId(id));
        }
    }
}
