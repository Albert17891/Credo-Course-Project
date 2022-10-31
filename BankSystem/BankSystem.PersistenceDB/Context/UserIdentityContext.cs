using BankSystem.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BankSystem.PersistenceDB.Context
{
    public class UserIdentityContext : IdentityDbContext<AppUser>
    {
        public UserIdentityContext(DbContextOptions<UserIdentityContext> options) : base(options)
        {

        }
    }
}
