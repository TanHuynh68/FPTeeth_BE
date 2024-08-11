namespace FPTeeth_BE.Enity
{
    public class WorkingTime : IEntity
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public Doctor? Doctor { get; set; }
        public int WorkingDayOfWeek { get; set; }
        public Slot? Slot { get; set; }
    }
}
