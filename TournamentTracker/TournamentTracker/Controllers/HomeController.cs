using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TournamentTrackerServices;
using TournamentTrackerServices.Services;

namespace TournamentTracker.Controllers
{
    public class HomeController : Controller
    {
        ITrackerService Services = new TrackerServices();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Active()
        {

            return View(Services.CreateFakeTournamentData());
        }
        public ActionResult Previous()
        {
            return View(Services.CreateFakeTournamentData());
        }
    }
}