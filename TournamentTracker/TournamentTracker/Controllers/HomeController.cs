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
        public ActionResult Creation(TournamentModel model,string[] PlayerList, string[] ModeratorList)
        {
            EFAuthService ef = new EFAuthService();

            //var test = Request.Form["ModeratorList"];
            model.OwnerEmail = User.Identity.Name;

            UserListModel players = new UserListModel();

            foreach (string player in PlayerList)
            {
                var grabbedUser = ef.GetUserFromId(player);

                players.UserList.Add(new MongoDAL.Models.User()
                {
                    Email = grabbedUser.Email,
                    Loses = 0,
                    Wins = 0
                });
            }

            model.PlayerList = players;

            UserListModel moderators = new UserListModel();

            foreach (string moderator in ModeratorList)
            {
                var grabbedUser = ef.GetUserFromId(moderator);

                moderators.UserList.Add(new MongoDAL.Models.User()
                {
                    Email = grabbedUser.Email,
                    Loses = 0,
                    Wins = 0
                });
            }

            model.ModeratorList = moderators;

            var temp = model;

            return RedirectToAction("Creation");
        }
    }
}