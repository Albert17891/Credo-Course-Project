
using MyCredoBanking.Service.Abstractions;
using MyCredoBanking.Service.Implementations;

namespace MyCredoBanking.Infrastracture.ServiceCollectionExtensions
{
<<<<<<<< HEAD:BankSystem/MyCredoBanking/Infrastracture/ServiceCollectionExtensions/ServiceExtension.cs
    public static class ServiceExtension
========
    public static class AddServicesExtension
>>>>>>>> 31ac0902ff3ef947ea4ac274f144610db12034df:BankSystem/MyCredoBanking/Infrastracture/ServiceCollectionExtensions/AddServicesExtension.cs
    {
        public static IServiceCollection AddServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<IOperatorService, OperatorService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
