using BankSystem.DataAccess.Abstractions;
using Mapster;
using MyCredoBanking.Service.Abstractions;
using MyCredoBanking.Service.Model;

namespace MyCredoBanking.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IContextWrapper _context;

        public UserService(IContextWrapper context)
        {
            _context = context;
        }

        public async Task<IList<UserAccountServiceModel>> GetAllAccount(string userId)
        {
            var AllAccount = await _context.userAccountRepository.GetAllAsync();
            var result = from account in AllAccount
                         where account.UserId == userId
                         select account;

            return result.Adapt<IList<UserAccountServiceModel>>();
        }

        public async Task<IList<CreditCardServiceModel>> GetAllCard(string userId)
        {
            var AllCard = await _context.cardRepository.GetAllAsync();

            var result = from card in AllCard
                         where card.UserId == userId
                         select card;

            return result.Adapt<IList<CreditCardServiceModel>>();
        }

        public Task InnerTransaction()
        {
            throw new NotImplementedException();
        }

        public Task OuterTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
