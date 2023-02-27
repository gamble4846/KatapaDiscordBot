using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KatapaDiscordBot.Commands.BasicCommands
{
    public static class HelpCommand
    {
        public static string ComamndName = "help";
        public async static Task Register(DiscordSocketClient _client)
        {
            var globalCommand = new SlashCommandBuilder();
            globalCommand.WithName(ComamndName);
            globalCommand.WithDescription("Help Command");
            globalCommand.AddOption("user", ApplicationCommandOptionType.User, "The users whos roles you want to be listed", isRequired: true);

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
