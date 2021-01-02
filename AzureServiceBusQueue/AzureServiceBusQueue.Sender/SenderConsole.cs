using AzureServiceBusQueue.Sender.Services;
using AzureServiceBusQueue.Shared.Models;
using System;
using System.Threading.Tasks;

namespace AzureServiceBusQueue.Sender
{
    class SenderConsole
    {
        static async Task Main(string[] args)
        {
            CabinetOrder order = new CabinetOrder
            {
                MaterialType = "Birch Wood",
                DoorSepcification = "Width - 12 in, Height - 20 in",
                NumberOfDoors = 1,
                DrawerSepcification = "Width - 12 in, Depth - 14 in, Height - 4 in",
                NumberOfDrawers = 2
            };

            await QueueService.SendMessageAsync(order);

            Console.WriteLine("Your message was successfully queued.");
        }
    }
}
