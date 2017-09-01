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
        private SqlConnection conn = MvcApplication.sqlConn;

        // GET: Challenge
        public ActionResult Index()
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
            return View(chList);
        }

        public ActionResult Detail(int? id)
        {
            List<ChallengeExtend> exList = new List<ChallengeExtend>();
            List<ChallengeDetail> dtList = new List<ChallengeDetail>();
            if (id.HasValue == false)
            {
                return View(dtList);
            }
            SqlCommand comm = new SqlCommand("select * from challengedetail where challengeid = " + id, conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                dtList.Add(new ChallengeDetail()
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
            return View(dtList);
        }
    }
}