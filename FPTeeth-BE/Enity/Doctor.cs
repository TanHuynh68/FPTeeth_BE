namespace FPTeeth_BE.Enity
{
    public class Doctor : IEntity
    {
        public int Id { get; set; }

        public string? DortorName { get; set; }

        public DateTime DoB { get; set; }

        public Account? Account { get; set; }

        public int? ClinicId { get; set; }
    }
}
