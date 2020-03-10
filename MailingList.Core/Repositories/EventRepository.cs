using System;
using MailingList.Core.Contexts;
using MailingList.Core.Entities;
using MailingList.Data;

namespace MailingList.Core.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(IEventContext eventContext)
            : base((EventContext)eventContext)
        {
        }
    }
}
