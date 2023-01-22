using AccountOwnerServer.Controllers;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(ApplicationDbContext Context)
            : base(Context)
        {
        }

      

        public IEnumerable<Owner> GetAllOwners()
        {
            return FindAll().OrderBy(a => a.Name).ToList();
        }

        public Owner GetOwnerByname(string name)
        {
            return  FindByCondition(a => a.Name == name).FirstOrDefault();
        }

        public Owner GetOwnerWithDetails(Guid ownerId)
        {
            return FindByCondition(a => a.Id.Equals(ownerId)).Include(a=>a.Accounts).FirstOrDefault();
        }
    }
}