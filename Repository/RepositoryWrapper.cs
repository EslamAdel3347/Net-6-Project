using AccountOwnerServer.Controllers;
using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositorywrapper
    {
        private ApplicationDbContext _Context;
        private IOwnerRepository _owner;
        private IAccountRepository _account;

        public RepositoryWrapper(ApplicationDbContext context)
        {
            _Context = context;
        }

     
        
        public IOwnerRepository Owner {

            get
            {
                if (_owner == null)
                {
                    _owner = new OwnerRepository(_Context);
                }
                return _owner;
            }
        }

        public IAccountRepository Account
        {

            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_Context);
                }
                return _account;
            }
        }

        public void Save()
        {
            _Context.SaveChanges();
        }
    }
}
