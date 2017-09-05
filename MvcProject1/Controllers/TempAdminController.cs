using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject1.Models;

namespace MvcProject1.Controllers
{
    public class TempAdminController : Controller
    {
        // GET: TempAdmin
        public ActionResult Index()
        {
            
            DataTable dt = MvcApplication.sqlConn.GetSchema("Tables");
            foreach (DataRow dr in dt.Rows)
            {
                Debug.WriteLine(dr.ToString());
            }
            return View();
        }
    }
}