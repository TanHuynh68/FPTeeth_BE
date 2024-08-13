using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Dtos
{
    public class AddClinicDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string Image { get; set; }

        public int OwnerId { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
