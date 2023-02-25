using Discord.Interactions;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace KatapaDiscordBot.Commands
{
    public class BasicCommands
    {
        public async Task SlashCommandHandler(SocketSlashCommand command)
        {
            await command.RespondAsync($"You executed {command.Data.Name}");
        }
    }
}
