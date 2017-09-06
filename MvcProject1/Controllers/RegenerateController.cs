using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MvcProject1.Models;
using SteamWebAPI2;
using SteamWebAPI2.Interfaces;

namespace MvcProject1.Controllers
{
    public class RegenerateController : Controller
    {
        // GET: Regenerate
        public async Task<ActionResult> Index()
        {
            //3416014558
            Match match = new Match();
            match = await match.GetMatchById(3416014558);
            return View(match);
        }
    }
}