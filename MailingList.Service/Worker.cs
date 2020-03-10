using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MailingList.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private static string apiUrl = "http://localhost:5005/api/email";

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //var request = WebRequest.Create(apiUrl);
                //request.Method = "GET";
                //request.ContentType = "application/json";
                //using (var response = request.GetResponse())
                //{
                //    using (var reponseStream = response.GetResponseStream())
                //    {
                //        using (var reader = new StreamReader(reponseStream))
                //        {
                //            var result = reader.ReadToEnd();
                //            //Console.WriteLine(result);
                //            dynamic items = JsonConvert.DeserializeObject(result);
                //            foreach (var item in items)
                //            {
                //                Console.WriteLine(item);
                //            }
                //        }
                //    }
                //}
                var client = new HttpClient();
                var httpResponse = client.GetAsync(apiUrl).Result;
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                var items = JsonConvert.DeserializeObject<List<EmailList>>(result);
                foreach (var item in items)
                {
                    var email = new Email
                    {
                        SenderName = "Event Authority",
                        Sender = "mollika.mrsk@gmail.com",
                        Receiver = item.Email,
                        Subject = $"About {item.Title}",
                        Body = $"Hello Mr. {item.Name}, We arrange event named {item.Title}; " +
                                    $"Dated:{item.Date}; Venue:{item.Venue}"
                    };

                    var request = WebRequest.Create(apiUrl);
                    request.Method = "POST";
                    request.ContentType = "application/json";

                    var requestContent = JsonConvert.SerializeObject(email);
                    var data = Encoding.UTF8.GetBytes(requestContent);
                    request.ContentLength = data.Length;

                    using (var requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(data, 0, data.Length);
                        requestStream.Flush();//
                    }
                    using (var response = request.GetResponse())
                    {
                        using (var responseStream = response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(responseStream))
                            {
                                var r = reader.ReadToEnd();
                                Console.WriteLine(r);
                            }
                        }
                    }
                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                //_logger.LogInformation($"{result}");



                await Task.Delay(5 * 1000, stoppingToken);
            }
        }
    }
}
