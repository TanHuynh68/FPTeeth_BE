using Newtonsoft.Json;

namespace FPTeeth_BE.Enity
{
    public class Medicine: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quatity { get; set; }

        public string Detail { get; set; }

        [JsonIgnore]
        public Booking Booking { get; set; }

    }
}
