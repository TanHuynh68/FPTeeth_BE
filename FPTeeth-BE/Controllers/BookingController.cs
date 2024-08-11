using FPTeeth_BE.Dtos;
using FPTeeth_BE.Enity;
using FPTeeth_BE.Service.IServices;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize("CUSTOMER")]
        [HttpPost("AddBooking")]
        public async Task<Booking> AddBooking([FromBody] BookingDto bookingDto)
        {
            return await _bookingService.AddBooking(bookingDto);
        }
    }
}
