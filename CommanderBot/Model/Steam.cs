using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenDotaApi;

namespace CommanderBot.Model
{
    class Steam
    {
        public static ulong GetSteam32(string url)
        {
            var steam64 = new Regex("https://steamcommunity.com/profiles/(.*)/").Match(url)
                .Groups[1].Value;
            return ulong.Parse(steam64) - 76561197960265728;
        }
    }
}
