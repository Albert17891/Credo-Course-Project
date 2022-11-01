
using MyCredoBanking.Service.Abstractions;
using MyCredoBanking.Service.Implementations;

namespace MyCredoBanking.Infrastracture.ServiceCollectionExtensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IOperatorService, OperatorService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
