namespace BankSystem.PersistenceDB.Context;

using BankSystem.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class IdentityContext : IdentityDbContext<AppUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {

    }
    public DbSet<UserAccount> UsersAccounts { get; set; }

    public DbSet<CreditCard> CreditCards { get; set; }

    public DbSet<Transactions> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
        modelbuilder.Entity<CreditCard>()
            .HasIndex(x => x.CardNumber).IsUnique();
        modelbuilder.Entity<UserAccount>()
            .HasIndex(x => x.Iban).IsUnique();
        modelbuilder.Entity<AppUser>()
            .HasIndex(x => x.IdNumber).IsUnique();

        foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelbuilder);
    }
}