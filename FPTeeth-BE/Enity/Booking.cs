namespace FPTeeth_BE.Enity
{
    public class Booking : IEntity
    {
        public int Id { get; set; }

        public int Status { get; set; }

        public Slot Slot { get; set; }

        public int Type { get; set; }

        public DateTime CreateAt { get; set; }

        public Customer customer { get; set; }

        public Doctor Doctor { get; set; }

        public ClinicService? ClinicService { get; set; }

        public string? Result { get; set; }

        public List<Medicine>? Medicines { get; set; }
    }
}
