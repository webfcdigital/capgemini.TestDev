using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.TestDev.Domain.Entities
{
    public class ValidateToken
    {
        public int CustomerId { get; set; }
        public Guid CardId { get; set; }
        public Guid Token { get; set; }
        public int CVV { get; set; }
    }
}
