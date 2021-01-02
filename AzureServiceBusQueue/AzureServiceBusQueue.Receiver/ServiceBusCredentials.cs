using System;
using System.Collections.Generic;
using System.Text;

namespace AzureServiceBusQueue.Receiver
{
    public class ServiceBusCredentials
    {
        public string ConnectionString { get; set; }
        public string QueueName { get; set; }
    }
}
