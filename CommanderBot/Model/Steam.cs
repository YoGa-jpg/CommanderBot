using System.Text.RegularExpressions;

namespace ProfileBot.Model
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
