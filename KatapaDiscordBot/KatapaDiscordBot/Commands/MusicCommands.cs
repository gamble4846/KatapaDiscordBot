using DSharpPlus.Entities;
using DSharpPlus;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatapaDiscordBot.Commands
{
    public class MusicCommands : ApplicationCommandModule
    {
        [SlashCommand("play", "Plays Music")]
        public async Task PlayCommand(InteractionContext ctx, [Option("SongName", "Name of the Song")] string SongName)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("Working On It...."));
            var embedMessage = new DiscordEmbedBuilder()
            {
                Title = SongName
            };

            await ctx.Channel.SendMessageAsync(embed: embedMessage);
        }
    }
}
