using AzureServiceBusQueue.Shared.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AzureServiceBusQueue.Sender.Services
{
    public static class ServiceProviderBuilder
    {
        public static ServiceBusCredentials GetSettingValues()
        {
            var services = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<ServiceBusCredentials>()
                .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();
            IConfigurationSection secureSettings = configuration.GetSection("ServiceBusCredentials");
            services.Configure<ServiceBusCredentials>(secureSettings);
            services.AddTransient<SettingValues>();
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider.GetService<SettingValues>().GetSettings();
        }
    }
}
