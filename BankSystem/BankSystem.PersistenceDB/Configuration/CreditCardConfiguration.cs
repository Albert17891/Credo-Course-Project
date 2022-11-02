using BankSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.PersistenceDB.Configuration;

public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder.Property(x => x.Pin).IsRequired();
        builder.Property(x => x.Cvv).IsRequired();
        builder.Property(x => x.CardNumber).IsRequired();
        builder.Property(x => x.CardExpireDate).IsRequired();

        builder.HasOne(x => x.User).WithMany(x => x.CreditCards).HasForeignKey(u => u.UserId);
        builder.HasOne(x => x.UserAccount).WithMany(x => x.CreditCards).HasForeignKey(u => u.UserAccountId);
    }
}