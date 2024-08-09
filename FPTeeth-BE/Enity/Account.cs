namespace FPTeeth_BE.Enity
{
    public class Account : IEntity
    {
        public int Id { get; set; }

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int? Gender { get; set; }

        public string? Image { get; set;}

        public int Status { get; set; }

        public DateTime UpdateAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public Role Role { get; set; }

    }
}
