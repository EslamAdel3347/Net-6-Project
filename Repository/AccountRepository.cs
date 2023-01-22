using AccountOwnerServer.Controllers;
using Entities;
using Entities.Models;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext Context)
            : base(Context)
        {
        }
    }
}