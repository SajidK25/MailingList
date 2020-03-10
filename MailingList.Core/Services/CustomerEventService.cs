using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MailingList.Core.Contexts;
using MailingList.Core.Entities;
using MailingList.Core.UnitOfWork;

namespace MailingList.Core.Services
{
    public class CustomerEventService : ICustomerEventService
    {
        private IEventUnitOfWork _eventUnitOfWork;
        public CustomerEventService(IEventUnitOfWork eventUnitOfWork)
        {
            _eventUnitOfWork = eventUnitOfWork;
        }

        public void AddNewCustomerEvent(CustomerEvent customerEvent)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomerEvent(int id)
        {
            throw new NotImplementedException();
        }

        public void EditCustomerEvent(CustomerEvent evnt)
        {
            throw new NotImplementedException();
        }

        public CustomerEvent GetCustomerEvent(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerEvent> GetCustomerEvents(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> ListToEmail()
        {
            return _eventUnitOfWork
                .CustomerEventRepository
                .GetCustomerEventList();
        }
    }
}
