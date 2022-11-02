using BankSystem.DataAccess.Abstractions;
using BankSystem.DataAccess.Services;

namespace MyCredoBanking.Infrastracture.ServiceCollectionExtensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositoryServcies(this IServiceCollection services)
    {
        services.AddScoped<IContextWrapper, ContextWrapper>();
        services.AddScoped<ICreditCardRepository, CreditCardRepository>();
        services.AddScoped<IUserAccountRepository, UserAccountRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        return services;
    }
}
