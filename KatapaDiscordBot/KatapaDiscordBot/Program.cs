using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatapaDiscordBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Bot = new Bot();
            Bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
