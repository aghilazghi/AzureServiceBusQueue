using AzureServiceBusQueue.Shared.Models;
using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace AzureServiceBusQueue.Receiver
{
    class ReceiverConsole
    {
        static IQueueClient queueClient;

        static async Task Main(string[] args)
        {
            ServiceBusCredentials credentials = ServiceProviderBuilder.GetSettingValues();
            queueClient = new QueueClient(credentials.ConnectionString, credentials.QueueName);

            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            queueClient.RegisterMessageHandler(ProcessMessageAsync, messageHandlerOptions);

            Console.ReadLine();

            await queueClient.CloseAsync();
        }

        private static async Task ProcessMessageAsync(Message message, CancellationToken token)
        {
            string jsonString = Encoding.UTF8.GetString(message.Body);
            CabinetOrder order = JsonSerializer.Deserialize<CabinetOrder>(jsonString);

            Console.WriteLine($"Processing order of cabinet. Material Type: {order.MaterialType}, " +
                $"Door Specification: {order.DoorSepcification}, Number Of Doors: {order.NumberOfDoors}" +
                $"Drawer Specification: {order.DrawerSepcification}, Number Of Drawer: {order.NumberOfDrawers}");

            await queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            Console.WriteLine($"Error has encountered while processing the message: { arg.Exception }");
            return Task.CompletedTask;
        }
    }
}
