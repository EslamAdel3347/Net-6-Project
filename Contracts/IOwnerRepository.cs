using Entities.Models;
using System.Collections.Generic;

namespace AccountOwnerServer.Controllers
{
    public interface IOwnerRepository:IRepositoryBase<Owner>
    {


  

        IEnumerable<Owner> GetAllOwners();

       Owner GetOwnerByname(string name);
        Owner GetOwnerWithDetails(Guid ownerId);
    }
}
