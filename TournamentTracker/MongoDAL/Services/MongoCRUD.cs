using MongoDAL.Interfaces;
using MongoDAL.Model;
using MongoDAL.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDAL.Services
{
    public static class MongoCRUD
    {
        

        #region ModelToBson
        private static BsonDocument UserToBson(User user)
        {
            BsonDocument toReturn = new BsonDocument();

            toReturn["email"] = user.Email;
            toReturn["firstName"] = user.FirstName;
            toReturn["lastName"] = user.LastName;
            toReturn["wins"] = user.Wins;
            toReturn["losses"] = user.Loses;

            return toReturn;
        }

        private static BsonArray UserListModelToBson(UserListModel users)
        {
            BsonArray toReturn = new BsonArray();

            foreach (var user in users.UserList)
            {
                toReturn.Add(UserToBson(user));
            }

            return toReturn;
        }

        private static BsonArray ScoreCardToBson(ScoreCard card)
        {
            BsonArray toReturn = new BsonArray();

            foreach (var item in card.RoundAndScores)
            {
                BsonDocument temp = new BsonDocument();
                temp["round"] = item.Key;
                temp["score"] = item.Value;
                toReturn.Add(temp);
            }
            
            return toReturn;
        }

        private static BsonArray PlayerWinLossTotalsToBson(List<KeyValuePair<User, ScoreCard>> winLossTotal)
        {
            BsonArray toReturn = new BsonArray();

            foreach (var total in winLossTotal)
            {
                BsonDocument temp = new BsonDocument();
                temp["user"] = UserToBson(total.Key);
                temp["scoreCard"] = ScoreCardToBson(total.Value);
                toReturn.Add(temp);
            }
            return toReturn;
        }

        private static BsonDocument TournamentModelToBson(TournamentModel toChange)
        {
            BsonDocument toReturn = new BsonDocument();

            toReturn["touramentId"] = toChange.TournamentId;
            toReturn["ownerEmail"] = toChange.OwnerEmail;
            toReturn["name"] = toChange.Name;
            toReturn["eliminationType"] = (int)toChange.EliminationType;
            toReturn["securityType"] = (int)toChange.SecurityType;
            toReturn["game"] = toChange.Game;
            toReturn["moderatorList"] = UserListModelToBson(toChange.ModeratorList);
            toReturn["playerList"] = UserListModelToBson(toChange.PlayerList);
            toReturn["playerWinLossTotals"] = PlayerWinLossTotalsToBson(toChange.PlayerWinLossTotals);
            toReturn["statusType"] = (int)toChange.StatusType;
            toReturn["playerLimit"] = toChange.PlayerLimit;
            return toReturn;
        }

        #endregion
        

        private static User BsonToUser(BsonValue bson)
        {
            User toReturn = new User();

            toReturn.Email = (string)bson["email"];
            toReturn.FirstName = (string)bson["firstName"];
            toReturn.LastName = (string)bson["lastName"];
            toReturn.Wins = (int)bson["wins"];
            toReturn.Loses = (int)bson["loses"];

            return toReturn;
        }


        private static UserListModel BsonToUserListModel(BsonArray users)
        {
            UserListModel toReturn = new UserListModel();

            foreach (var item in users)
            {
                toReturn.UserList.Add(BsonToUser(item));
            }

            return toReturn;
        }
        
        private static TournamentModel BsonToTournamentModel()
        {
            throw new NotImplementedException();
        }
        
        #region Read

        public static TournamentListModel GetAllActiveTournament()
        {
            TournamentListModel listModel = new TournamentListModel();
            TournamentModel model = new TournamentModel();

            using (var context = new MongoConnection())
            {
                var query = context.ActiveCollection.Database;
                //model = ReturnModel(query);
                listModel.TournamentList.Add(model);
            }

            return listModel;
        }

        public static TournamentListModel GetAllInactiveTournaments()
        {
            throw new NotImplementedException();
        }


        public static TournamentListModel GetTournamentsByOwnerEmail(string ownerEmail)
        {
            throw new NotImplementedException();
        }

        public static TournamentModel GetTournamentById(int tournamentId)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Create
        public static void CreateTournament(TournamentModel tournament)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Modify
        public static void ModifyTournamentById(int tournamentId, TournamentModel changeTo)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Delete
        public static void DeleteTournamentById(int tournamentId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
