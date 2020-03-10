using System;
using System.Collections.Generic;
using MailingList.Core.Entities;
using MailingList.Data;

namespace MailingList.Core.Repositories
{
    public interface ICustomerEventRepository : IRepository<CustomerEvent>
    {
        List<dynamic> GetCustomerEventList();
    }
}
