using CredoReport.Service.Abstractions;
using CredoReport.Service.Service;

namespace CredoReport.Infrastracture.ServiceCollectionExtensions;

public static class ServicesExtensions

{
    public static IServiceCollection AddServicesExtension(this IServiceCollection services)
    {
        services.AddScoped<IUserStatisticService, UserStatisticService>();
        services.AddScoped<ITransactionStatisticService, TransactionStatisticService>();

        return services;
    }
}

