using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureServiceBusQueue.Receiver
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
