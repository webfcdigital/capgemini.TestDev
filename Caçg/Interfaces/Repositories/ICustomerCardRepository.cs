using Capgemini.TestDev.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.TestDev.Domain.Interfaces.Repositories
{
   public interface ICustomerCardRepository : IRepository<CustomerCard>
    {

        public Task<CustomerCard> GetByCardId(Guid CardId);
    }
}
