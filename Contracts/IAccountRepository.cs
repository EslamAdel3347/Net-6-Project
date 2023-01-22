using Entities.Models;

namespace AccountOwnerServer.Controllers
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {


        //IQueryable<Owner> FindByType(string type);



    }
}
