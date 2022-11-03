using AtmCredoBanking.Service.Abstractions;
using AtmCredoBanking.Service.Implementations;

namespace CredoATM.Infrastracture.ServiceCollectionExtensions;

public static class ServicesExtensions

{
    public static IServiceCollection AddServicesExtension(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ICardService, CardService>();

        return services;
    }
}

