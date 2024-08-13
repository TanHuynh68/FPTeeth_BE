namespace FPTeeth_BE.Dtos
{
    public class AddDoctorDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int? Gender { get; set; }
        public string Description { get; set; }
    }
}
