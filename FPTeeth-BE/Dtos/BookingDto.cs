using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Dtos
{
    public class BookingDto
    {
        public int Slot { get; set; }

        public int Type { get; set; }

        public DateTime BookingDate { get; set; }

        public int CustomerId { get; set; }

        public int DoctorID { get; set; }

        public int ClinicId { get; set; }

        public int ServiceId { get; set; }
    }
}
