using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDAL;
using MongoDAL.Models;
using MongoDAL.Services;

namespace TournamentTracker.Controllers
{
    public class HomeController : Controller
    {  
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Active()
        {
            var model = MongoCRUD.GetAllActiveTournament();

            return View(model);
        }
        public ActionResult Previous()
        {
            var model = MongoCRUD.GetAllInactiveTournaments();

            return View(model);
        }

        public ActionResult Detail(string tournamentId)
        {
            var model =  MongoCRUD.GetTournamentById(tournamentId);

            return View(model);
        }

        [Authorize]
        public ActionResult Creation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Creation(TournamentModel model)
        {


            return RedirectToAction("Creation");
        }
    }
}