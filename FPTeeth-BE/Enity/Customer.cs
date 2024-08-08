namespace FPTeeth_BE.Enity
{
    public class Customer : IEntity
    {
        public int Id { get; set; }

        public string? CustomerName { get; set; }

        public string? Phone { get; set; }

        public string? DoB { get; set; }

        public string? Address { get; set; }

        public Account Account { get; set; }

    }
}
