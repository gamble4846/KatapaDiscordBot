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

            _client.MessageReceived += async (message) =>
            {
                if (message.Content.StartsWith("!ping"))
                {
                    await message.Channel.SendMessageAsync("Pong!");
                }
            };
            _client.Ready += Client_Ready;
            _client.SlashCommandExecuted += SlashCommandHandler;

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

        public async Task Client_Ready()
        {
            var globalCommand = new SlashCommandBuilder();
            globalCommand.WithName("first-global-command");
            globalCommand.WithDescription("This is my first global slash command");

            try
            {
                await _client.CreateGlobalApplicationCommandAsync(globalCommand.Build());
            }
            catch (Exception ex)
            {
                var json = JsonConvert.SerializeObject(ex.Message, Formatting.Indented);
                Console.WriteLine(json);
            }
        }

        private async Task SlashCommandHandler(SocketSlashCommand command)
        {
            await command.RespondAsync($"You executed {command.Data.Name}");
        }
    }
}
