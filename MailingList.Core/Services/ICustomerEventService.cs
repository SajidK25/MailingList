using System;
using System.Collections.Generic;
using MailingList.Core.Entities;

namespace MailingList.Core.Services
{
    public interface ICustomerEventService
    {
        IEnumerable<CustomerEvent> GetCustomerEvents(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);
        IEnumerable<dynamic> ListToEmail();
        void AddNewCustomerEvent(CustomerEvent customerEvent);
        CustomerEvent GetCustomerEvent(int id);
        void EditCustomerEvent(CustomerEvent evnt);
        void DeleteCustomerEvent(int id);
    }
}
