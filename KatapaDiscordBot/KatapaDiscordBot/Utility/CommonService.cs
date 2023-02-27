using Discord;
using Discord.Audio;
using Discord.Commands;
using Discord.WebSocket;
using KatapaDiscordBot.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace KatapaDiscordBot.Utility
{
    public static class CommonService
    {
        public static async Task<ConfigJSONModel> GetConfigJSONObject()
        {
            var json = String.Empty;
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync();

            var configJson = JsonConvert.DeserializeObject<ConfigJSONModel>(json);

            return configJson;
        }

        public static string FirstToUpper(string inputString)
        {
            if (inputString.Length == 0)
            {
                return inputString;
            }  
            else if (inputString.Length == 1)
            {
                return char.ToUpper(inputString[0]).ToString();
            }
            else
            {
                return (char.ToUpper(inputString[0]) + inputString.Substring(1));
            } 
        }

        public async static Task JoinChannel(DiscordSocketClient client, SocketSlashCommand command, ICommandContext Context, IVoiceChannel channel = null)
        {
            channel = channel ?? (Context.User as IGuildUser)?.VoiceChannel;
            if (channel == null) { await Context.Channel.SendMessageAsync("User must be in a voice channel, or a voice channel must be passed as an argument."); return; }

            // For the next step with transmitting audio, you would want to pass this Audio Client in to a service.
            var audioClient = await channel.ConnectAsync();
        }

        public async static Task PlayAudio(DiscordSocketClient client, SocketSlashCommand command, ICommandContext Context, IVoiceChannel channel = null)
        {
            channel = channel ?? (command.User as IGuildUser)?.VoiceChannel;
            var audioClient = await channel.ConnectAsync();

            using (var mp3Stream = new System.IO.FileStream("test.mp3", System.IO.FileMode.Open))
            {
                var audioStream = audioClient.CreatePCMStream(AudioApplication.Music);
                await mp3Stream.CopyToAsync(audioStream);
                await audioStream.FlushAsync();
            }
        }
    }
}
