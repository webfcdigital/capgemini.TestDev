using Capgemini.TestDev.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.TestDev.Business.Interfaces
{
    public interface ICustomerCardService
    {
        Task<bool> ValidateToken(ValidateToken validate);
        ResponseSaveCardNumber SaveCard(RequestSaveCardNumber request);
    }
}
