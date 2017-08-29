using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotaChallenge.Controllers
{
    public class ChallengeController : Controller
    {
        // GET: Challenge
        public ActionResult Index()
        {
            return View();
        }
    }
}