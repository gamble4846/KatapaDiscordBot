using Discord;
using Discord.Commands;
using Discord.WebSocket;
using KatapaDiscordBot.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatapaDiscordBot.Commands.AudioCommands
{
    public class PlayCommand
    {
        public static string ComamndName = "play";
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

            await CommonService.JoinChannel(client, command, Context);
            await CommonService.PlayAudio(client, command, Context);
        }
    }
}
