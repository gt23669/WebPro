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
        public string OwnerEmail { get; set; }
        public string Name { get; set; }
        public TournamentTypes EliminationType { get; set; }
        public SecurityLevels SecurityType { get; set; }
        public string Game { get; set; }
        public List<User> AdminList { get; set; }
        public List<User> PlayerList { get; set; }
        public List<KeyValuePair<User, ScoreCard>> PlayerWinLossTotals { get; set; }
        public Status StatusType { get; set; }

        private int playerLimit = 32;
        public int PlayerLimit
        {
            get { return playerLimit; }
            set { playerLimit = value > 0 && value < 129 ? value : playerLimit; }
        }


        #region Constructors

        public TournamentModel()
        {

        }
        public TournamentModel(string name, TournamentTypes eliminationType, SecurityLevels securityType, List<User> admins)
        {
            Name = name;
            EliminationType = eliminationType;
            SecurityType = securityType;
            AdminList = admins;
            StatusType = Status.Open;

        }
        public TournamentModel(string name, TournamentTypes eliminationType, SecurityLevels securityType, User admin)
        {
            Name = name;
            EliminationType = eliminationType;
            SecurityType = securityType;
            AdminList = new List<User>
            {
                admin
            };
            StatusType = Status.Open;

        }
        public TournamentModel(string name, TournamentTypes eliminationType, SecurityLevels securityType, User admin, string game)
        {
            Name = name;
            EliminationType = eliminationType;
            SecurityType = securityType;
            AdminList = new List<User>
            {
                admin
            };
            Game = game;
            StatusType = Status.Open;

        }
        public TournamentModel(string name, TournamentTypes eliminationType, SecurityLevels securityType, User admin, string game, List<User> players)
        {
            Name = name;
            EliminationType = eliminationType;
            SecurityType = securityType;
            AdminList = new List<User>
            {
                admin
            };
            Game = game;
            PlayerList = players;
            StatusType = Status.Open;

        }

        #endregion

        #region Methods

        public void AddPlayer(User player)
        {
            PlayerList.Add(player);
        }

        public void AddPlayerList(List<User> players)
        {
            players.ForEach(p => PlayerList.Add(p));
        }

        public void AddAdmin(User player, User Authorizer)
        {
            if (AdminList.Contains(Authorizer))
            {
                AdminList.Add(player);
            }
        }

        public void AddAdminList(List<User> players, User Authorizer)
        {
            if (AdminList.Contains(Authorizer))
            {
                players.ForEach(p => PlayerList.Add(p));
            }
        }

        public bool IsClosed()
        {
            return StatusType == Status.Ended;
        }

        #endregion

    }
}
