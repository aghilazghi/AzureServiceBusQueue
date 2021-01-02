using System;
using System.Collections.Generic;
using System.Text;

namespace AzureServiceBusQueue.Sender.Services
{
    public class ServiceBusCredentials
    {
        public string ConnectionString { get; set; }
        public string QueueName { get; set; }
    }
}
