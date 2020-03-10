using System;
using System.Collections.Generic;
using MailingList.Core.Entities;

namespace MailingList.Core.Services
{
    public interface IEventService
    {
        IEnumerable<Event> GetEvents(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);
        void AddNewEvent(Event evnt);
        Event GetEvent(int id);
        void EditEvent(Event evnt);
        void DeleteEvent(int id);
    }
}
