using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcProject1.Models;
using PortableSteam;

namespace MvcProject1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static SqlConnection sqlConn;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //my connection
            sqlConn = ChallengeDataBase.ConnectDataBase();
            SteamWebAPI.SetGlobalKey("4CE963A0198750BC26CF9355706F2686");
        }
    }
}
