using BankSystem.DataAccess.Abstractions;
using MyCredoBanking.Service.Abstractions;

namespace MyCredoBanking.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IContextWrapper _context;

        public UserService(IContextWrapper context)
        {
            _context = context;
        }

        public Task<IList<string>> GetAllAccount(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetAllCard(string userId)
        {
            throw new NotImplementedException();
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
