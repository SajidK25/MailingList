using System;
using MailingList.Core.Contexts;
using MailingList.Core.Repositories;
using MailingList.Data;

namespace MailingList.Core.UnitOfWork
{
    public interface IEventUnitOfWork : IUnitOfWork<EventContext>
    {
        IEventRepository EventRepository { get; set; }
        ICustomerRepository CustomerRepository { get; set; }
        ICustomerEventRepository CustomerEventRepository { get; set; }
    }
}
