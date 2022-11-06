namespace BankSystem.PersistenceDB.Configuration;

using BankSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TransactionsConfiguration : IEntityTypeConfiguration<Transactions>
{
    public void Configure(EntityTypeBuilder<Transactions> builder)
    {
        builder.HasOne(x => x.User).WithMany(x => x.Transactions).HasForeignKey(x => x.UserId);
    }
}
