using BankSystem.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BankSystem.PersistenceDB.Context
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }
        public DbSet<UserAccount> UsersAccounts { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<Transactions> Transactions { get; set; }
    }
}
