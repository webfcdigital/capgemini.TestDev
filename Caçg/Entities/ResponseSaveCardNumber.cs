using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.TestDev.Domain.Entities
{
    public class ResponseSaveCardNumber
    {
        public DateTime CreationDate { get; set; }
        public Guid Token { get; set; }
        public Guid CardId { get; set;  }
    }
}
