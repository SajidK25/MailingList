using System;
using System.Collections;
using System.Collections.Generic;

namespace MailingList.Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public IList<CustomerEvent> CustomerEvents { get; set; }
    }
}
