using System;
namespace MailingList.Core.Entities
{
    public class EmailMessage
    {
        public string Sender { get; set; }
        public string SenderName { get; set; }
        public string Receiver { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
