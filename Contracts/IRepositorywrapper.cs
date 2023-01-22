using AccountOwnerServer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositorywrapper
    {
        IOwnerRepository Owner { get; }
        IAccountRepository Account { get;  }
        void Save();
    }
}
