namespace BankSystem.PersistenceDB.Seed;

using BankSystem.Domain.Models;
using BankSystem.Domain.Models.Enum;
using BankSystem.PersistenceDB.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class UserSeed
{
    public static async Task AddUserAndRoles(IApplicationBuilder builder)
    {
        using (var scope = builder.ApplicationServices.CreateScope())
        {
            var service = scope.ServiceProvider;
            var userContext = service.GetRequiredService<IdentityContext>();
            var userManager = service.GetRequiredService<UserManager<AppUser>>();
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

            Migrate(userContext);
            await SeedRolesAsync(roleManager);
            await SeedOperatorAsync(userManager, roleManager);
        }
    }

    private static void Migrate(IdentityContext context)
    {
        context.Database.Migrate();
    }
    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole(RolesEnum.Operator.ToString()));
        await roleManager.CreateAsync(new IdentityRole(RolesEnum.User.ToString()));
    }

    private static async Task SeedOperatorAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        var admin = new AppUser()
        {
            FirstName = "Albert",
            LastName = "Gevorkyan",
            UserName = "Operator",
            Email = "abo@gmail.com",
            IdNumber = "47001034566",
            BirthDate = DateTime.Parse("1994/07/01"),
            RegisterTime=DateTime.Now,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        if (userManager.Users.All(u => u.Id != admin.Id))
        {
            var user = await userManager.FindByEmailAsync(admin.Email);
            if (user == null)
            {
                await userManager.CreateAsync(admin, "Aa123456!");
                await userManager.AddToRoleAsync(admin, RolesEnum.Operator.ToString());
            }
        }
    }
}