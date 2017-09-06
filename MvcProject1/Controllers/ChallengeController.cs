using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject1.Models;
using System.Data.SqlClient;

namespace MvcProject1.Controllers
{
    public class ChallengeController : Controller
    {
        private static SqlConnection conn = MvcApplication.SqlConn;

        private static List<Challenges> challengeList = InitChallenge();

        // GET: Challenge
        public ActionResult Index()
        {
            return View(challengeList);
        }

        public ActionResult Detail(int? id)
        {
            Challenges ch = new Challenges();
            if (id == null)
                return View(ch);
            ch = challengeList.FirstOrDefault(x => x.ChallengeId == id);
            if (ch.GetHashCode() == 0)
                return View(ch);
            ch.ChallengeDetails = new List<ChallengeDetail>();
            SqlCommand comm = new SqlCommand("select * from challengedetail where challengeid = " + ch.ChallengeId, conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                ch.ChallengeDetails.Add(new ChallengeDetail()
                {
                    DetailId = reader.GetInt32(0),
                    ChallengeId = reader.GetInt32(1),
                    MatchId = reader.GetInt32(2),
                    UserId = reader.GetInt32(3),
                    UserName = reader.GetString(4),
                    HerroName = reader.GetString(5),
                    HeroLevel = reader.GetInt32(6),
                    Score = reader.GetInt32(7),
                    GameDuration = reader.GetInt32(8),
                    InventoryId = reader.GetInt32(9)
                });
            }
            reader.Close();
            return View(ch);
        }

        public static List<Challenges> InitChallenge()
        {
            List<Challenges> chList = new List<Challenges>();
            SqlCommand comm = new SqlCommand("select * from challenges", conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                chList.Add(new Challenges()
                {
                    ChallengeId = reader.GetInt32(0),
                    ChallengeName = reader.GetString(1),
                    ChallengeDesc = reader.GetString(2)
                });
            }
            reader.Close();
            for (int i = 0; i < chList.Count; i++)
            {
                chList[i].NextCh = i + 1 < chList.Count ? chList[i + 1].ChallengeId : chList[0].ChallengeId;
                chList[i].PrevCh = i - 1 >= 0 ? chList[i - 1].ChallengeId : chList[chList.Count - 1].ChallengeId;
            }
            return (chList);
        }
    }
}