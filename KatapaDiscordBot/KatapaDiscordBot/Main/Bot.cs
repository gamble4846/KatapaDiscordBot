using Discord.WebSocket;
using Discord;
using KatapaDiscordBot.Utility;
using System.Threading.Tasks;

namespace KatapaDiscordBot.Main
{
    public class Bot
    {
        public async Task RunAsync()
        {
            var ConfigJson = await CommonService.GetConfigJSONObject();

            DiscordSocketConfig config = new DiscordSocketConfig
            {
                GatewayIntents = GatewayIntents.All
            };

            DiscordSocketClient client = new DiscordSocketClient(config);
            await client.LoginAsync(TokenType.Bot, ConfigJson.Token);
            await client.StartAsync();

            client.MessageReceived += async (message) =>
            {
                if (message.Content.StartsWith("!ping"))
                {
                    await message.Channel.SendMessageAsync("Pong!");
                }
            };

            await Task.Delay(-1);
        }
    }
}
