using BankSystem.DataAccess.Abstractions;
using Moq;
using MyCredoBanking.Service.Implementations;

namespace MyCredoBanking.Service.Tests;

public class TransactionTests
{
    private readonly Mock<IContextWrapper> contextWrapper = new Mock<IContextWrapper>();

    [Fact]
    public async Task Transaction_Should_Return_False_If_Sender_Amount_Is_Not_Enough()
    {


        var transaction = new TestTransactionModel()
        {
            RecieverAccountId = 1,
            SenderAccountId = 2,
            Amount = 300
        };

        var senderAccount = new TestUserAccountModel()
        {
            Amount = 50
        };

        var reciverAccount = new TestUserAccountModel()
        {
            Amount = 35
        };


        contextWrapper.Setup(x => x.userAccountRepository.GetByKeyAsync(1)).ReturnsAsync(senderAccount);

        contextWrapper.Setup(x => x.userAccountRepository.GetByKeyAsync(2)).ReturnsAsync(reciverAccount);

        UserService userService2 = new UserService(contextWrapper.Object);

        var res = await userService2.Transaction(transaction);


        Assert.False(res);
    }
}