using Capgemini.TestDev.Data.Context;
using Capgemini.TestDev.Domain.Interfaces.Repositories;
using Capgemini.TestDev.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.TestDev.Data.Repositories
{
    public class CustomerCardRepository : Repository<CustomerCard>, ICustomerCardRepository
    {
        public CustomerCardRepository(TestDevContext testDevContext) : base(testDevContext)
        {

        }

        public async Task<CustomerCard> GetByCardId(Guid CardId)
        {
            try
            {
                var cardId = await _testDevContext.Set<CustomerCard>().Where(x => x.CardId == CardId).FirstOrDefaultAsync();
                return cardId; 
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
