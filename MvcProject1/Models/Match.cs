using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject1.Models
{
    public class Match
    {
        public uint MatchId { get; set; }
        public List<Player> Players { get; set; }
    }

    public class Player
    {
        public long SteamId { get; set; }
        public int HeroId { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assist { get; set; }
    }
}