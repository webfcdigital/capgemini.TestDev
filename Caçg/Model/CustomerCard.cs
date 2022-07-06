using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.TestDev.Domain.Model
{
    public class CustomerCard
    {
        public int CustomerId { get; set; }
        public Guid CardId { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }
        public DateTime DateCreation { get; set; }
        public Guid Token { get; set; }
    }
}
