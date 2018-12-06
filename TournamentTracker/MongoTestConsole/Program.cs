using MongoDAL.Model;
using MongoDAL.Models;
using MongoDAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TournamentModel model = new TournamentModel()
            {
                TournamentId = "Apple",
                OwnerEmail = "Apple@Pi.yum",
                Name = "Pie Eating Contest",
                EliminationType = TournamentTypes.RoundRobin,
                SecurityType = SecurityLevels.Open,
                Game = "Consuming",
                ModeratorList = new UserListModel()
                {
                    UserList = new List<User>()
                    {
                        new User()
                        {
                            Email = "Apple@Pi.yum",
                            FirstName = "Jimmy",
                            LastName = "Turner",
                            Wins = 10,
                            Loses = 6
                        }
                    }
                },
                PlayerList = new UserListModel()
                {
                    UserList = new List<User>()
                    {
                        new User()
                        {
                            Email = "Apple@Pi.yum",
                            FirstName = "Jimmy",
                            LastName = "Turner",
                            Wins = 10,
                            Loses = 6
                        },
                        new User()
                        {
                            Email = "Me@Here.now",
                            FirstName = "James",
                            LastName = "Jacob",
                            Wins = 20,
                            Loses = 80
                        }
                    }
                },
                PlayerWinLossTotals = new List<KeyValuePair<User, ScoreCard>>()
                {
                    new KeyValuePair<User, ScoreCard>
                    (
                        new User()
                        {
                                Email = "Apple@Pi.yum",
                                FirstName = "Jimmy",
                                LastName = "Turner",
                                Wins = 10,
                                Loses = 6
                        },
                        new ScoreCard()
                        {
                            RoundAndScores = new List<KeyValuePair<int, int>>()
                            {
                                new KeyValuePair<int, int>(1,5),
                                new KeyValuePair<int, int>(2,3)
                            }
                        }
                    )
                },
                PlayerLimit = 16

            };


            var result = MongoCRUD.GetTournamentsByOwnerEmail("dpcorum@yahoo.com");

            MongoCRUD.DeleteTournamentById("Apple");

            Console.ReadLine();

        }

    }
}