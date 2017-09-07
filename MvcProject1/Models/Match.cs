using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Steam.Models.DOTA2;

namespace MvcProject1.Models
{
    public class Global
    {
        public static IReadOnlyCollection<GameItemModel> AllItem { get; set; }

        public class Match
        {
            public ulong MatchId { get; set; }
            public List<Player> Players { get; set; }

            public async Task<Match> GetMatchById(ulong matchId)
            {
                Match m = new Match();
                var tmp = await MvcApplication.MatchInterface.GetMatchDetailsAsync(matchId);
                var tmpIt = await MvcApplication.EconInterface.GetGameItemsAsync();
                AllItem = tmpIt.Data;
                m.MatchId = tmp.Data.MatchId;
                m.Players = new List<Player>();
                foreach (var el in tmp.Data.Players)
                {
                    m.Players.Add(new Player().GetPlayer(el));
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

            public Player GetPlayer(MatchPlayerModel playerM)
            {
                Player player = new Player
                {
                    SteamId = playerM.AccountId,
                    HeroId = playerM.PlayerSlot,
                    Kills = playerM.Kills,
                    Deaths = playerM.Deaths,
                    Assist = playerM.Assists,
                    Items = new List<Item>
                    {
                        new Item().GetItemById(playerM.Item0),
                        new Item().GetItemById(playerM.Item1),
                        new Item().GetItemById(playerM.Item2),
                        new Item().GetItemById(playerM.Item3),
                        new Item().GetItemById(playerM.Item4),
                        new Item().GetItemById(playerM.Item5)
                    }
                };
                return player;
            }
        }

        public class Item
        {
            public uint ItemId { get; set; }
            public string ItemName { get; set; }
            public string IconPath { get; set; }

            public Item GetItemById(uint itemId)
            {
                Item it = new Item
                {
                    ItemId = itemId,
                    ItemName = AllItem.FirstOrDefault(x => x.Id == itemId)?.Name
                };
                if (it.ItemName != null)
                {
                    it.ItemName = it.ItemName.Substring(5);
                    //var tmp2 = await MvcApplication.EconInterface.GetItemIconPathAsync(it.ItemName);
                    it.IconPath = "http://cdn.dota2.com/apps/dota2/images/items/" + it.ItemName + "_lg.png";
                }
                else
                {
                    it.IconPath = "~/Content/Images/default-placeholder.png";
                }
                return it;
            }
        }
    }
}