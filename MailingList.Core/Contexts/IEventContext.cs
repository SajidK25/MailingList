using System;
using MailingList.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MailingList.Core.Contexts
{
    public interface IEventContext
    {
        DbSet<Event> events { get; set; }
        DbSet<Customer> customers { get; set; }
        DbSet<CustomerEvent> customerEvents { get; set; }
    }
}
