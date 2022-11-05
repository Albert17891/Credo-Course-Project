namespace BankSystem.PersistenceDB.Configuration;

using BankSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder.Property(x => x.Pin).IsRequired();
        builder.Property(x => x.Cvv).IsRequired();

        builder.HasIndex(x => x.CardNumber).IsUnique();

        builder.Property(x => x.CardNumber).IsRequired();
        builder.Property(x => x.CardExpireDate).IsRequired();

        builder.HasOne(x => x.User).WithMany(x => x.CreditCards).HasForeignKey(u => u.UserId);
        builder.HasOne(x => x.UserAccount).WithMany(x => x.CreditCards).HasForeignKey(u => u.UserAccountId);
    }
}