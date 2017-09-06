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
            Match match1 = new Match();
            match1.Players = new List<Player>();
            match1.MatchId = 3416014558;
            var match = await MvcApplication.MatchInterface.GetMatchDetailsAsync(3416014558);
            var players = match.Data.Players;
            foreach (var el in players)
            {
                match1.Players.Add(new Player()
                {
                    SteamId = el.AccountId,
                    HeroId = el.HeroId,
                    Kills = el.Kills,
                    Assist = el.Assists,
                    Deaths = el.Deaths
                });
            }
            return View(match1);
        }
    }
}