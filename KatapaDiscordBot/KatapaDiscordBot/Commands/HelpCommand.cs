using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatapaDiscordBot.Commands
{
    public class HelpCommand : ApplicationCommandModule
    {
        [SlashCommand("hello", "Says hello to the user.")]
        public async Task HelloCommand(InteractionContext ctx, [Option("String","LOL")] string testString)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("Working On It...."));
            var embedMessage = new DiscordEmbedBuilder()
            {
                Title = testString
            };

            await ctx.Channel.SendMessageAsync(embed: embedMessage);
        }
    }
}
