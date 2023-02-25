using Discord.WebSocket;
using Discord;
using KatapaDiscordBot.Utility;
using System.Threading.Tasks;
using Discord.Net;
using Newtonsoft.Json;
using System;
using KatapaDiscordBot.Commands;

namespace KatapaDiscordBot.Main
{
    public class Bot
    {
        private DiscordSocketClient _client;
        public async Task RunAsync()
        {
            var ConfigJson = await CommonService.GetConfigJSONObject();

            DiscordSocketConfig config = new DiscordSocketConfig
            {
                GatewayIntents = GatewayIntents.All
            };
            _client = new DiscordSocketClient(config);
            _client.Log += Log;
            var token = ConfigJson.Token;

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
