using System;
using System.Collections.Generic;
using System.Linq;
using MailingList.Core.Contexts;
using MailingList.Core.Entities;
using MailingList.Data;
using Microsoft.EntityFrameworkCore;

namespace MailingList.Core.Repositories
{
    public class CustomerEventRepository : Repository<CustomerEvent>, ICustomerEventRepository
    {
        private readonly IEventContext _eventContext;
        public CustomerEventRepository(IEventContext eventContext)
            : base((EventContext)eventContext)
        {
            _eventContext = eventContext;
        }

        public List<dynamic> GetCustomerEventList()
        {
            return _eventContext.customerEvents
                .Where(ce => ce.IsEmailSent == false)
                .Select(e => new
                {
                    e.Customer.Name,
                    e.Customer.Address,
                    e.Customer.Email,
                    e.Customer.MobileNo,
                    e.Event.Title,
                    e.Event.Date,
                    e.Event.Venue,
                    e.IsEmailSent
                }).ToList<dynamic>();

            //return _eventContext.customerEvents
            //    .Where(ce => ce.IsEmailSent == false)
            //    .Include(e => e.Customer)
            //    .Include(e => e.Event).ToList();
        }
    }
}
