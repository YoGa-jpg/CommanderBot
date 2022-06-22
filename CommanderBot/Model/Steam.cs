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
        private OpenDota Dota;
        public Steam()
        {
            Dota = new OpenDota();
        }

        public async Task<int?> GetProfile(string url)
        {
            var id = new Regex("https://steamcommunity.com/profiles/(.*)/").Match(url)
                .Groups[1].Value;
            var player = await Dota.Players.GetPlayerAsync(long.Parse(id) - 76561197960265728);
            return player.MmrEstimate.Estimate.Value;
        }
    }
}
