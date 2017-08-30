using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject1.Models
{
    public class Challenges
    {
        public int ChallengeId { get; set; }
        public string ChallengeName { get; set; }
        public string ChallengeDesc { get; set; }
    }

    public class ChallengeDetail
    {
        public int MatchId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string HerroName { get; set; }
        public int Score { get; set; }
        public int Duration { get; set; }
    }
}