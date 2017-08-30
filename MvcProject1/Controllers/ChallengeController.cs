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
        // GET: Challenge
        public List<Challenges> chList = new List<Challenges>();
        public ActionResult Index()
        {
            ChallengeDataBase db = new ChallengeDataBase();
            SqlConnection conn = db.ConnectDataBase();
            SqlCommand comm = new SqlCommand("select * from challenges", conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                chList.Add(new Challenges(){ ChallengeId = reader.GetInt32(0), ChallengeName = reader.GetString(1), ChallengeDesc = reader.GetString(2)});
            }
            return View(chList);
        }

        public ActionResult Detail(int id)
        {
            
            return View();
        }
    }
}