using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MvcProject1.Controllers
{
    public class SteamIdController : Controller
    {
        // GET: SteamId
        public string Index()
        {
            string id = "153975899";
            return id;
        }
    }
}