using AzureServiceBusQueue.Shared.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureServiceBusQueue.Sender.Services
{
    public class SettingValues
    {
        private readonly ServiceBusCredentials setting;

        public SettingValues(IOptions<ServiceBusCredentials> setting)
        {
            this.setting = setting.Value;
        }

        public ServiceBusCredentials GetSettings()
        {
            return setting;
        }
    }
}
