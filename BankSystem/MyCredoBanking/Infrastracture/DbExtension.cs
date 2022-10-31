using BankSystem.Domain.Models;
using BankSystem.PersistenceDB.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MyCredoBanking.Infrastracture.Extensions;

public static class DbExtension
{
    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:sqlConnection"];

        services.AddDbContext<BankingSystemContext>(option => option.UseSqlServer(connectionString));

        services.AddIdentity<AppUser, IdentityRole>(opt =>
        {
            opt.User.RequireUniqueEmail = true;

        }).AddEntityFrameworkStores<UserIdentityContext>();

        services.AddDbContext<UserIdentityContext>(option => option.UseSqlServer(connectionString));

        return services;
    }
}