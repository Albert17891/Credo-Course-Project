using BankSystem.Domain.Models;
using BankSystem.Domain.Models.Models.Transactions;
using BankSystem.Domain.Models.Transaction;
using BankSystem.Domain.Models.Transactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.PersistenceDB.Context;

public class BankingSystemContext : DbContext
{
    public BankingSystemContext(DbContextOptions<BankingSystemContext> options)
        : base(options)
    {

    }

    public DbSet<UserAccount> UsersAccounts { get; set; }

    public DbSet<CreditCard> CreditCards { get; set; }

    public DbSet<AtmTransaction> AtmTransactions { get; set; }

    public DbSet<ExchangeTransaction> ExchangeTransactions { get; set; }

    public DbSet<SendToOtherTransaction> SendToOthers { get; set; }

    public DbSet<SentToMeTransaction> InsideTransactions { get; set; }
}