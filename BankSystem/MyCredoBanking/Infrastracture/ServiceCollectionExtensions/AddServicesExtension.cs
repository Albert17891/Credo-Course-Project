
using MyCredoBanking.Service.Abstractions;
using MyCredoBanking.Service.Implementations;

namespace MyCredoBanking.Infrastracture.ServiceCollectionExtensions
{
    public static class AddServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOperatorService, OperatorService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
