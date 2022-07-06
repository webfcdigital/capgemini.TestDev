using Capgemini.TestDev.Data.Context;
using Capgemini.TestDev.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.TestDev.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestDevContext _context;

        public UnitOfWork(TestDevContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
