using System;
namespace MailingList.Core.Entities
{
    public class CustomerEvent
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public bool IsEmailSent { get; set; } = false;
    }
}
