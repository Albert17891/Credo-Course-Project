namespace MyCredoBanking.Infrastracture.ServiceCollectionExtensions;

using MyCredoBanking.Service.Abstractions;
using MyCredoBanking.Service.Implementations;

public static class ServicesExtensions

{
    public static IServiceCollection AddServicesExtension(this IServiceCollection services)
    {
        services.AddScoped<IOperatorService, OperatorService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITransactionHelperService, TransactionHelperService>();

        return services;
    }
}