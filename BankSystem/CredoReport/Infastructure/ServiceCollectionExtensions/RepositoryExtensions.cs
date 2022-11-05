namespace CredoReport.Infrastracture.ServiceCollectionExtensions;

using BankSystem.DataAccess.Abstractions;
using BankSystem.DataAccess.Services;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositoryServcies(this IServiceCollection services)
    {
        services.AddScoped<IContextWrapper, ContextWrapper>();
        services.AddScoped<IUserRepository, UserRepository>();       
        return services;
    }
}