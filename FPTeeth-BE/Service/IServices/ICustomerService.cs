using FPTeeth_BE.Enity;

namespace FPTeeth_BE.Service.IServices
{
    public interface ICustomerService
    {
        Task<List<Customer>> getAllPatientOfClinic(int clinicId);
    }
}
