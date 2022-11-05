namespace CredoReport.Infrastracture.ServiceCollectionExtensions;

using BankSystem.Domain.Models;
using BankSystem.PersistenceDB.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


public static class DbExtension
{
    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:sqlConnection"];

        services.AddDbContext<IdentityContext>(option => option.UseSqlServer(connectionString));

        services.AddIdentity<AppUser, IdentityRole>(opt =>
        {
            opt.User.RequireUniqueEmail = true;             

        }).AddEntityFrameworkStores<IdentityContext>();

        return services;
    }
}