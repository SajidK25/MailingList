using System;
using MailingList.Core.Contexts;
using MailingList.Core.Entities;
using MailingList.Data;

namespace MailingList.Core.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IEventContext eventContext)
            : base((EventContext)eventContext)
        {
        }
    }
}
