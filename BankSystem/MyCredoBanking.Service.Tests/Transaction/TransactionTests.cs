using BankSystem.DataAccess.Abstractions;
using FluentAssertions;
using Moq;
using MyCredoBanking.Service.Implementations;

namespace MyCredoBanking.Service.Tests.Transaction;

public class TransactionTests
{
    private Mock<IContextWrapper> _contextWrapper;

    private readonly UserService _service;

    public TransactionTests()
    {
        _contextWrapper = new Mock<IContextWrapper>();
        _service = new UserService(_contextWrapper.Object);
    }

    [Fact]
    public async Task Transaction_Should_Throw_ArgumentNullException_If_Request_Is_Null()
    {
        // Arrange
        TestTransactionModel request = default;

        // Act & Assert
        await FluentActions.Invoking(async () => await _service.Transaction(request))
            .Should().ThrowExactlyAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task Transaction_Should_Return_False_If_Sender_Amount_Is_Not_Enough()
    {

        // Arrange
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

        _contextWrapper.Setup(x => x.userAccountRepository.GetByKeyAsync(1)).ReturnsAsync(senderAccount);
        _contextWrapper.Setup(x => x.userAccountRepository.GetByKeyAsync(2)).ReturnsAsync(reciverAccount);

        // Act
        var res = await _service.Transaction(transaction);

        // Assert
        Assert.False(res);
    }
}