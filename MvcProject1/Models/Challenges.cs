using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject1.Models
{
    public class ChallengeExtend
    {
        public IEnumerable<Challenges> Challengeses { get; set; }
        public IEnumerable<ChallengeDetail> ChallengeDetails { get; set; }
        //public Challenges Challenges { get; set; }
        //public ChallengeDetail ChallengeDetail { get; set; }
    }

    public class Challenges
    {
        public int ChallengeId { get; set; }
        public string ChallengeName { get; set; }
        public string ChallengeDesc { get; set; }
    }

    public class ChallengeDetail
    {
        public int DetailId { get; set; }
        public int ChallengeId { get; set; }
        public int MatchId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string HerroName { get; set; }
        public int HeroLevel { get; set; }
        public int Score { get; set; }
        public int GameDuration { get; set; }
        public int InventoryId { get; set; }
    }
}