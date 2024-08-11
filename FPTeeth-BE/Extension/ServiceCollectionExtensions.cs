using FPTeeth_BE.Repositories;
using FPTeeth_BE.Service;
using FPTeeth_BE.Service.IServices;

namespace FPTeeth_BE.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IClinicService, ClinicService>();
            services.AddScoped<IWorkingTimeService, WorkingTimeService>();
            services.AddScoped<IBookingService, BookingService>();
        }
    }
}
