using FPTeeth_BE.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FPTeeth_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController: ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("GetByPatientId/{patientId}")]
        public async Task<IActionResult> GetByPatientId(int patientId)
        {
            return Ok( await _bookingService.GetAllByPatientId(patientId));
        }
        
        [HttpPatch("UpdateResult/{id}")]
        public async Task<IActionResult> UpdateResult (int id, string result)
        {
            return Ok( await _bookingService.UpdateResult(id, result));
        }
    }
}
