using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace DotaChallenge.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
    }
}