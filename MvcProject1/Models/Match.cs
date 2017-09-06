using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Steam.Models.DOTA2;

namespace MvcProject1.Models
{
    public class Match
    {
        public ulong MatchId { get; set; }
        public List<Player> Players { get; set; }

        public async Task<Match> GetMatchById (ulong matchId)
        {
            Match m = new Match();
            var tmp = await MvcApplication.MatchInterface.GetMatchDetailsAsync(matchId);
            m.MatchId = tmp.Data.MatchId;
            m.Players = new List<Player>();
            foreach (var el in tmp.Data.Players)
            {
                m.Players.Add(await new Player().GetPlayer(el));
            }
            return m;
        }
    }

    public class Player
    {
        public long SteamId { get; set; }
        public uint HeroId { get; set; }
        public uint Kills { get; set; }
        public uint Deaths { get; set; }
        public uint Assist { get; set; }
        public List<Item> Items { get; set; }

        public async Task<Player> GetPlayer (MatchPlayerModel playerM)
        {
            Player player = new Player();
            player.SteamId = playerM.AccountId;
            player.HeroId = playerM.PlayerSlot;
            player.Kills = playerM.Kills;
            player.Deaths = playerM.Deaths;
            player.Assist = playerM.Assists;
            player.Items = new List<Item>
            {
                await new Item().GetItemById(playerM.Item0),
                await new Item().GetItemById(playerM.Item1),
                await new Item().GetItemById(playerM.Item2),
                await new Item().GetItemById(playerM.Item3),
                await new Item().GetItemById(playerM.Item4),
                await new Item().GetItemById(playerM.Item5),
            };
            return player;
        }
    }

    public class Item
    {
        public uint ItemId { get; set; }
        public string ItemName { get; set; }
        public string IconPath { get; set; }

        public async Task<Item> GetItemById(uint itemId)
        {
            Item it = new Item();
            it.ItemId = itemId;
            var tmp = await MvcApplication.EconInterface.GetGameItemsAsync();
            it.ItemName = tmp.Data.FirstOrDefault(x => x.Id == itemId)?.Name;
            if (it.ItemName != null)
            {
                it.ItemName = it.ItemName.Substring(5);
                it.IconPath = "http://cdn.dota2.com/apps/dota2/images/items/" + it.ItemName + "_lg.png";
            }
            else
            {
                it.IconPath = "~/Content/Imges/default_image.jpg";
            }
            return it;
        }
    }


}