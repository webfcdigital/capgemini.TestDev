using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.TestDev.Domain.Entities
{
    public class RequestSaveCardNumber
    {
        public int CustomerId { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }

    }
}
