using System;
using System.Collections.Generic;
using MailingList.Core.Entities;
using MailingList.Core.UnitOfWork;

namespace MailingList.Core.Services
{
    public class EventService : IEventService
    {
        private IEventUnitOfWork _eventUnitOfWork;
        public EventService(IEventUnitOfWork eventUnitOfWork)
        {
            _eventUnitOfWork = eventUnitOfWork;
        }

        public void AddNewEvent(Event evnt)
        {
            _eventUnitOfWork.EventRepository.Add(evnt);
            _eventUnitOfWork.Save();
        }

        public void DeleteEvent(int id)
        {
            _eventUnitOfWork.EventRepository.Remove(id);
            _eventUnitOfWork.Save();
        }

        public void EditEvent(Event evnt)
        {
            var oldEvent = _eventUnitOfWork.EventRepository.GetById(evnt.Id);
            oldEvent.Title = evnt.Title;
            oldEvent.Date = evnt.Date;
            oldEvent.Venue = evnt.Venue;
            _eventUnitOfWork.Save();
        }

        public Event GetEvent(int id)
        {
            return _eventUnitOfWork.EventRepository.GetById(id);
        }

        public IEnumerable<Event> GetEvents(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            return _eventUnitOfWork.EventRepository.Get(
                out total,
                out totalFiltered,
                x => x.Title.Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }
    }
}
