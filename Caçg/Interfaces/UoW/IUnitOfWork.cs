using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.TestDev.Domain.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
