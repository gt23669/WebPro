using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentTrackerServices.Enums;
using TournamentTrackerServices.Model;

namespace TournamentTrackerServices.Services
{
    public class TrackerServices : ITrackerService
    {
        public TournamentListModel CreateFakeTournamentData()
        {
            TournamentListModel results = new TournamentListModel
            {
                TournamentList = new List<Tournament>()
            };
            UserListModel userList = new UserListModel
            {
                UserList = new List<User>()
            {
                new User()
                {
                    FirstName = "Daniel",
                    LastName = "Corum",
                    Wins = 5,
                    Loses = 0
                },
                new User()
                {
                    FirstName = "Steven",
                    LastName = "Crawford",
                    Wins = 10,
                    Loses = 2
                }
            }
            };
            ;
            Tournament tournament = new Tournament()
            {
                Name = "Test1",
                Game = "Poker",
                Type = (TournamentTypes)0,
                PlayerList = userList.UserList

            };
            results.TournamentList.Add(tournament);

            tournament = new Tournament()
            {
                Name = "Test2",
                Game = "Smash",
                Type = (TournamentTypes)1,
                PlayerList = userList.UserList
            };
            results.TournamentList.Add(tournament);
            tournament = new Tournament()
            {
                Name = "Test3",
                Game = "League",
                Type = (TournamentTypes)2,
                PlayerList = userList.UserList
            };
            results.TournamentList.Add(tournament);
            return results;
        }

        public UserListModel GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public TournamentListModel GetListOfTournaments()
        {
            throw new NotImplementedException();
        }

        public Tournament GetTournamentByName(string name)
        {
            throw new NotImplementedException();
        }

        public UserListModel GetTournamentUsers()
        {
            throw new NotImplementedException();
        }
    }
}
