namespace FPTeeth_BE.Enity
{
    public class Slot : IEntity
    {
        public int Id { get; set; }

        public int Status { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
