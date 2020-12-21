using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Manav
{
    public class LogService
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger _clientLogger;
        private readonly ILogger _commandLogger;

        public LogService(DiscordSocketClient client, CommandService commands, ILoggerFactory loggerFactory)
        {
            _client = client;
            _commands = commands;
            _loggerFactory = ConfigureLogging(loggerFactory);
            _clientLogger = _loggerFactory.CreateLogger("discord");
            _commandLogger = _loggerFactory.CreateLogger("commands");
        }

        private ILoggerFactory ConfigureLogging(ILoggerFactory factory)
        {
            return factory;
        }
    }
}
