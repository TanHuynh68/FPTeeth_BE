namespace FPTeeth_BE.Enity
{
    public class Doctor : IEntity
    {
        public int Id { get; set; }

        public DateTime DoB { get; set; }

        public Account? Account { get; set; }

    }
}
