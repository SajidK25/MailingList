using System;
using System.Collections.Generic;
using MailingList.Core.Entities;

namespace MailingList.Core.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);
        void AddNewCustomer(Customer customer);
        Customer GetCustomer(int id);
        void EditCustomer(Customer evnt);
        void DeleteCustomer(int id);
    }
}
