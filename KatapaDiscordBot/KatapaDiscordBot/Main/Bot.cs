using Discord.WebSocket;
using Discord;
using KatapaDiscordBot.Utility;
using System.Threading.Tasks;
using Discord.Net;
using Newtonsoft.Json;
using System;
using KatapaDiscordBot.Commands;
using KatapaDiscordBot.Commands.BasicCommands;
using System.Reflection;
using System.Collections.Generic;
using KatapaDiscordBot.Commands.AudioCommands;
using Discord.Commands;

namespace KatapaDiscordBot.Main
{
    public class Bot : ModuleBase
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
            await HelpCommand.Register(_client);
            await GreetCommand.Register(_client);
            await PlayCommand.Register(_client);
        }


        private async Task SlashCommandHandler(SocketSlashCommand command)
        {
            switch (command.Data.Name)
            {
                case "help":
                    await HelpCommand.Handle(command, _client, Context);
                    break;
                case "greet":
                    await GreetCommand.Handle(command, _client, Context);
                    break;
                case "play":
                    await PlayCommand.Handle(command, _client, Context);
                    break;
                default:
                    await command.RespondAsync($"Command Not Found!!");
                    break;
            }
        }
    }
}
