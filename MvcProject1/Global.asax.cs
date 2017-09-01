using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcProject1.Models;

namespace MvcProject1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static SqlConnection sqlConn;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            sqlConn = ChallengeDataBase.ConnectDataBase();
        }
    }
}
