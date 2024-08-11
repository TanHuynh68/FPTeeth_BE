namespace FPTeeth_BE.Enity
{
    public class Clinics : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Address { get; set; }

        public string? Image { get; set; }

        public int Status { get; set; }

        public Account? Owner { get; set; }

        public List<Doctor>? Doctors { get; set; }

        public DateTime CreateAt {  get; set; }

        public DateTime UpdateAt { get; set; }

    }
}
