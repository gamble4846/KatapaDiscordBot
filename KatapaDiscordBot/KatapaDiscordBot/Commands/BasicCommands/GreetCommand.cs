using Discord.WebSocket;
using Discord;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace KatapaDiscordBot.Commands.BasicCommands
{
    public class GreetCommand
    {
        public static string ComamndName = "greet";
        public async static Task Register(DiscordSocketClient _client)
        {
            var globalCommand = new SlashCommandBuilder();
            globalCommand.WithName(ComamndName);
            globalCommand.WithDescription("Greet Command");

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

        public async static Task Handle(SocketSlashCommand command, DiscordSocketClient client, ICommandContext Context)
        {
            await command.RespondAsync($"You executed {command.Data.Name}");
        }
    }
}
