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
        public uint HeroId { get; set; }
        public uint Kills { get; set; }
        public uint Deaths { get; set; }
        public uint Assist { get; set; }
        public string Item0 { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public string Item4 { get; set; }
        public string Item5  { get; set; }
    }
}