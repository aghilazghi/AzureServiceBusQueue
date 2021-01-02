using AzureServiceBusQueue.Shared.Models;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureServiceBusQueue.Sender.Services
{
    public class QueueService
    {       
        public static async Task SendMessageAsync<T>(T serviceBusMessage)
        {
            ServiceBusCredentials credentials = ServiceProviderBuilder.GetSettingValues();
            QueueClient client = new QueueClient(credentials.ConnectionString, credentials.QueueName);
            string messageBody = JsonSerializer.Serialize(serviceBusMessage);
            Message message = new Message(Encoding.UTF8.GetBytes(messageBody));

            await client.SendAsync(message);
        }
    }
}
