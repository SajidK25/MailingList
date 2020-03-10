using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MailingList.Core.Entities;
using MailingList.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MailingList.API.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private ICustomerEventService _customerEventService;
        private IConfiguration _config;
        public EmailController(ICustomerEventService customerEventService,
            IConfiguration config)
        {
            _customerEventService = customerEventService;
            _config = config;
        }
        // GET: api/valuesŌ
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var list = _customerEventService.ListToEmail();
            return list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]EmailMessage message)
        {
            try
            {
                var emailService = new EmailService(_config);
                emailService.Send(message);
            }
            catch (Exception ex)
            {

            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
