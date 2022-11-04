using BankSystem.DataAccess.Abstractions;
using BankSystem.DataAccess.Services;

namespace CredoReport.Infrastracture.ServiceCollectionExtensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositoryServcies(this IServiceCollection services)
    {
        services.AddScoped<IContextWrapper, ContextWrapper>();
        services.AddScoped<IUserRepository, UserRepository>();       
        return services;
    }
}
