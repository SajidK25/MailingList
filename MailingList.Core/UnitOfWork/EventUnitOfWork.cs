using System;
using MailingList.Core.Contexts;
using MailingList.Core.Repositories;
using MailingList.Data;

namespace MailingList.Core.UnitOfWork
{
    public class EventUnitOfWork : UnitOfWork<EventContext>, IEventUnitOfWork
    {
        public EventUnitOfWork(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {
            EventRepository = new EventRepository(_dbContext);
            CustomerRepository = new CustomerRepository(_dbContext);
            CustomerEventRepository = new CustomerEventRepository(_dbContext);
        }

        public IEventRepository EventRepository { get; set; }
        public ICustomerRepository CustomerRepository { get; set; }
        public ICustomerEventRepository CustomerEventRepository { get; set; }
    }
}
