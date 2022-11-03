using BankSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.PersistenceDB.Configuration;

public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.Property(x => x.Currency).IsRequired();

        builder.HasIndex(x => x.Iban).IsUnique();

        builder.Property(x => x.Iban).IsRequired();

        builder.HasOne(x => x.User).WithMany(x => x.UserAccounts).HasForeignKey(u => u.UserId);

        //builder.HasMany(x => x.CreditCards).WithOne(x => x.UserAccount).HasForeignKey(x => x.AccountId);
    }
}
