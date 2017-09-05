using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PortableSteam;

namespace MvcProject1.Controllers
{
    public class SteamIdController : Controller
    {
        // GET: SteamId
        public string Index()
        {
            string id = "153975899";

            var st = SteamWebAPI.Game().Dota2().IDOTA2Match().GetMatchHistory().GetResponse();

            return id;
        }
    }
}