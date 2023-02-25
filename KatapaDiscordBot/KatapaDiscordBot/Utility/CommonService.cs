using KatapaDiscordBot.Models;
using Newtonsoft.Json;
using System;
using System.IO;
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
    }
}
