using System;
using System.Collections.Generic;
using MailingList.Core.Entities;
using MailingList.Core.UnitOfWork;

namespace MailingList.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private IEventUnitOfWork _eventUnitOfWork;

        public CustomerService(IEventUnitOfWork eventUnitOfWork)
        {
            _eventUnitOfWork = eventUnitOfWork;
        }

        public void AddNewCustomer(Customer customer)
        {
            _eventUnitOfWork.CustomerRepository.Add(customer);
            _eventUnitOfWork.Save();
        }

        public void DeleteCustomer(int id)
        {
            _eventUnitOfWork.CustomerRepository.Remove(id);
            _eventUnitOfWork.Save();
        }

        public void EditCustomer(Customer customer)
        {
            var oldCustomer = _eventUnitOfWork.CustomerRepository.GetById(customer.Id);
            oldCustomer.Name = customer.Name;
            oldCustomer.Address = customer.Address;
            oldCustomer.MobileNo = customer.MobileNo;
            oldCustomer.Email = customer.Email;
            _eventUnitOfWork.Save();
        }

        public Customer GetCustomer(int id)
        {
            return _eventUnitOfWork.CustomerRepository.GetById(id);
        }

        public IEnumerable<Customer> GetCustomers(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            return _eventUnitOfWork.CustomerRepository.Get(
                out total,
                out totalFiltered,
                x => x.Name.Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }
    }
}
