using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcProject1.Models;
using SteamWebAPI2.Interfaces;

namespace MvcProject1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static SqlConnection SqlConn;
        public static DOTA2Match MatchInterface;
        public static DOTA2Econ EconInterface;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //my connection
            string SteamWebApiKey = "4CE963A0198750BC26CF9355706F2686";
            SqlConn = ChallengeDataBase.ConnectDataBase();
            MatchInterface = new DOTA2Match(SteamWebApiKey);
            EconInterface = new DOTA2Econ(SteamWebApiKey);
        }
    }
}
