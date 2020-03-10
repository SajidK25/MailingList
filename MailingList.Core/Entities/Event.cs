using System;
using System.Collections.Generic;

namespace MailingList.Core.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Venue { get; set; }
        public IList<CustomerEvent> CustomerEvents { get; set; }
    }
}
