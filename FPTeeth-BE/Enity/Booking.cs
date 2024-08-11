namespace FPTeeth_BE.Enity
{
    public class Booking : IEntity
    {
        public int Id { get; set; }

        public int Status { get; set; }

        public Slot Slot { get; set; }

        public int Type { get; set; }

        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public DateTime BookingDate { get; set;}

        public Customer Customer { get; set; }

        public Doctor Doctor { get; set; }

        public ClinicService ClinicsService { get; set; }

        public string BookingAddress { get; set; }

        public string BookingName { get; set; }

        public string? Result { get; set; }

        public List<Medicine>? Medicines { get; set; }
    }
}
