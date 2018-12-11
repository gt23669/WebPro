using MongoDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDAL.Models
{
    public class TournamentModel
    {
        

        #region Properties
        public string TournamentId { get; set; }
        public string OwnerEmail { get; set; }
        public string Name { get; set; }
        public TournamentTypes EliminationType { get; set; }
        public SecurityLevels SecurityType { get; set; }
        public string Game { get; set; }
        public UserListModel ModeratorList { get; set; }
        public UserListModel PlayerList { get; set; }
        public List<KeyValuePair<User, ScoreCard>> PlayerWinLossTotals { get; set; }
        public Status StatusType { get; set; }
        private int playerLimit = 32;
        public int PlayerLimit
        {
            get { return playerLimit; }
            set { playerLimit = value > 0 && value < 129 ? value : playerLimit; }
        }
        #endregion

        #region Constructors

        public TournamentModel()
        {

        }
        public TournamentModel(string name, TournamentTypes eliminationType, SecurityLevels securityType, UserListModel moderators)
        {
            Name = name;
            EliminationType = eliminationType;
            SecurityType = securityType;
            ModeratorList = moderators;
            StatusType = Status.Open;

        }
        public TournamentModel(string name, TournamentTypes eliminationType, SecurityLevels securityType, User moderator)
        {
            Name = name;
            EliminationType = eliminationType;
            SecurityType = securityType;
            ModeratorList = new UserListModel
            {
                UserList = new List<User>()
                {
                    moderator
                }
            };
            StatusType = Status.Open;

        }
        public TournamentModel(string name, TournamentTypes eliminationType, SecurityLevels securityType, User moderator, string game)
        {
            Name = name;
            EliminationType = eliminationType;
            SecurityType = securityType;
            ModeratorList = new UserListModel
            {
                UserList = new List<User>()
                {
                    moderator
                }
            };
            Game = game;
            StatusType = Status.Open;

        }
        public TournamentModel(string name, TournamentTypes eliminationType, SecurityLevels securityType, User moderator, string game, UserListModel players)
        {
            Name = name;
            EliminationType = eliminationType;
            SecurityType = securityType;
            ModeratorList = new UserListModel
            {
                UserList = new List<User>()
                {
                    moderator
                }
            };
            PlayerList = players;
            StatusType = Status.Open;

        }

        #endregion

        #region Methods

        public void AddPlayer(User player)
        {
            PlayerList.UserList.Add(player);
        }

        public void AddPlayerList(List<User> players)
        {
            players.ForEach(p => PlayerList.UserList.Add(p));
        }

        public void AddAdmin(User player, User Authorizer)
        {
            if (ModeratorList.UserList.Contains(Authorizer))
            {
                ModeratorList.UserList.Add(player);
            }
        }

        public void AddAdminList(List<User> players, User Authorizer)
        {
            if (ModeratorList.UserList.Contains(Authorizer))
            {
                players.ForEach(p => PlayerList.UserList.Add(p));
            }
        }

        public bool IsClosed()
        {
            return StatusType == Status.Ended;
        }


        public static TournamentModel GetRandomizedTournament()
        {
            Random rand = new Random();

            string id = "";
            string game = "";
            for (int i = 0; i < 20; i++)
            {
                id.Append((char)rand.Next(48, 122));
                game.Append((char)rand.Next(48, 122));
            }

            char chara = (char)rand.Next();
            string Owner = "";

            TournamentModel TM = new TournamentModel()
            {
                TournamentId = id,
                OwnerEmail = Owner,
                Name = id,
                EliminationType = (TournamentTypes)rand.Next(0, 3),
                SecurityType = (SecurityLevels)rand.Next(0, 2),
                Game = game,
                ModeratorList = new UserListModel() {
                    UserList = new List<User>() {
                        new User()
                        {
                            Email = "J@J.com",
                            FirstName = "J",
                            LastName = "J",
                            Wins = 2,
                            Loses = 1
                        }} },
                PlayerList = new UserListModel(),
                PlayerWinLossTotals = new List<KeyValuePair<User, ScoreCard>>(),
                StatusType = (Status)rand.Next(0, 4),
                playerLimit = 32,
            };

            return TM;
        }

        #endregion

    }
}
