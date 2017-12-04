using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeStatusDashboard.Models;

namespace EmployeeStatusDashboard.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : Controller
    {
        private GEPTestEntities db = new GEPTestEntities();

        /// <summary>
        /// GET: Home
        /// </summary>
        /// <returns>Returns ActionResult</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
