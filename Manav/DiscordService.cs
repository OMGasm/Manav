using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Manav
{
    class DiscordService : Microsoft.Extensions.Hosting.BackgroundService
    {
        private IConfiguration _config;
        private DiscordSocketClient _client;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _client = new();
            _config = BuildConfig();
            var services = ConfigureServices();
            services.GetRequiredService<LogService>();
            await Task.Delay(-1, stoppingToken);
        }

        private IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandlingService>()
                .AddLogging()
                .AddSingleton<LogService>()
                .AddSingleton(_config)
                .BuildServiceProvider();
        }

        private IConfiguration BuildConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", true)
                .Build();
        }
    }
}
