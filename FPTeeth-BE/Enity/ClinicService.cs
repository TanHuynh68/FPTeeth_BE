namespace FPTeeth_BE.Enity
{
    public class ClinicService : IEntity
    {
        public int Id { get; set;}

        public Clinics? Clinics { get; set;}

        public Services? Services { get; set;}
    }
}
