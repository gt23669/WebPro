using MongoDAL.Interfaces;
using MongoDAL.Model;
using MongoDAL.Models;
using MongoDB.Bson;
using MongoDB.Driver;
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

            toReturn["tournamentId"] = toChange.TournamentId;
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

        #region BsonToModel
        private static KeyValuePair<User, ScoreCard> BsonToUserScoreCard(BsonValue document)
        {
            KeyValuePair<User, ScoreCard> toReturn;

            User userToAdd = BsonToUser(document["user"]);
            ScoreCard scoreCardToAdd = BsonToScoreCard((BsonArray)document["scoreCard"]);
            toReturn = new KeyValuePair<User, ScoreCard>(userToAdd, scoreCardToAdd);

            return toReturn;
        }

        private static ScoreCard BsonToScoreCard(BsonArray scoreCard)
        {
            ScoreCard toReturn = new ScoreCard();

            foreach (var item in scoreCard)
            {
                KeyValuePair<int, int> toAdd = new KeyValuePair<int, int>((int)item["round"], (int)item["score"]);
                toReturn.RoundAndScores.Add(toAdd);
            }

            return toReturn;
        }

        private static User BsonToUser(BsonValue bson)
        {
            User toReturn = new User();

            toReturn.Email = (string)bson["email"] ?? "";
            toReturn.FirstName = (string)bson["firstName"] ?? "";
            toReturn.LastName = (string)bson["lastName"] ?? "";
            toReturn.Wins = (int)bson["wins"];
            toReturn.Loses = (int)bson["losses"];

            return toReturn;
        }
        private static List<KeyValuePair<User, ScoreCard>> BsonToPlayerWinLossTotals(BsonArray totals)
        {
            List<KeyValuePair<User, ScoreCard>> toReturn = new List<KeyValuePair<User, ScoreCard>>();

            foreach (BsonValue item in totals)
            {
                KeyValuePair<User, ScoreCard> temp = BsonToUserScoreCard(item);
                toReturn.Add(temp);
            }

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

        private static TournamentModel BsonToTournamentModel(BsonDocument bson)
        {
            TournamentModel toReturn = new TournamentModel();

            toReturn.TournamentId = (string)bson["tournamentId"] ?? "";
            toReturn.OwnerEmail = (string)bson["ownerEmail"] ?? "";
            toReturn.Name = (string)bson["name"] ?? "";
            toReturn.EliminationType = (TournamentTypes)(int)bson["eliminationType"];
            toReturn.SecurityType = (SecurityLevels)(int)bson["securityType"];
            toReturn.Game = (string)bson["game"];
            toReturn.ModeratorList = BsonToUserListModel((BsonArray)bson["moderatorList"]);
            toReturn.PlayerList = BsonToUserListModel((BsonArray)bson["playerList"]);
            toReturn.PlayerWinLossTotals = BsonToPlayerWinLossTotals((BsonArray)bson["playerWinLossTotals"]);
            toReturn.StatusType = (Status)(int)bson["statusType"];
            toReturn.PlayerLimit = (int)bson["playerLimit"];

            return toReturn;
        }

        #endregion


        #region Read


        public static TournamentListModel GetAllActiveTournament()
        {
            TournamentListModel listModel = new TournamentListModel();

            using (var service = new MongoConnection())
            {
                var results = service.ActiveCollection.Find(x => true).ToList();
                foreach (var item in results)
                {
                    TournamentModel temp = BsonToTournamentModel(item);
                    listModel.TournamentList.Add(temp);
                }
            }
            return listModel;
        }

        public static TournamentListModel GetAllInactiveTournaments()
        {
            TournamentListModel listModel = new TournamentListModel();

            using (var service = new MongoConnection())
            {
                var results = service.InActiveCollection.Find(x => true).ToList();
                foreach (var item in results)
                {
                    TournamentModel temp = BsonToTournamentModel(item);
                    listModel.TournamentList.Add(temp);
                }
            }
            return listModel;
        }


        public static TournamentListModel GetTournamentsByOwnerEmail(string ownerEmail)
        {
            TournamentListModel listModel = new TournamentListModel();

            using (var service = new MongoConnection())
            {
                var results = service.ActiveCollection.Find(x => x["ownerEmail"] == ownerEmail).ToList();
                foreach (var item in results)
                {
                    TournamentModel temp = BsonToTournamentModel(item);
                    listModel.TournamentList.Add(temp);
                }
                results = service.InActiveCollection.Find(x => x["ownerEmail"] == ownerEmail).ToList();
                foreach (var item in results)
                {
                    TournamentModel temp = BsonToTournamentModel(item);
                    listModel.TournamentList.Add(temp);
                }
            }
            return listModel;
        }

        public static TournamentModel GetTournamentById(string tournamentId)
        {
            using (MongoConnection service = new MongoConnection())
            {

                var results = service.ActiveCollection.Find(c => c["tournamentId"] == tournamentId).ToList();
                if (results.Count == 0)
                {
                    results = service.InActiveCollection.Find(c => ((string)c["tournamentId"]).ToUpper() == tournamentId.ToUpper() && !string.IsNullOrEmpty((string)c["tournamentId"])).ToList();

                }
                var result = (results.Count == 0) ? new BsonDocument() : results[0];
                return BsonToTournamentModel(result);// BsonToTournamentModel(result);

            }

        }

        #endregion

        #region Create
        public static void CreateTournament(TournamentModel tournament)
        {
            using (MongoConnection service = new MongoConnection())
            {
                service.ActiveCollection.InsertOne(TournamentModelToBson(tournament));
            }
        }
        #endregion

        #region Update
        public static void ModifyTournamentById(string tournamentId, TournamentModel changeTo)
        {
            using (MongoConnection service = new MongoConnection())
            {
                if(service.ActiveCollection.CountDocuments(x => x["tournamentId"] == tournamentId) != 0)
                {
                    service.ActiveCollection.FindOneAndReplace(x => x["tournamentId"] == tournamentId, TournamentModelToBson(changeTo));
                }
                else if(service.InActiveCollection.CountDocuments(x => x["tournamentId"] == tournamentId) != 0)
                {
                    service.InActiveCollection.FindOneAndReplace(x => x["tournamentId"] == tournamentId, TournamentModelToBson(changeTo));
                }
            }
        }
        
        public static void ActiveToInactive(string tournamentId)
        {
            using (MongoConnection service = new MongoConnection())
            {
                if(service.ActiveCollection.CountDocuments(x => x["tournamentId"] == tournamentId) != 0)
                {
                    service.InActiveCollection.InsertOne(service.ActiveCollection.Find(x => x["tournamentId"] == tournamentId).ToList()[0]);
                    service.ActiveCollection.FindOneAndDelete(x => x["tournamentId"] == tournamentId);

                    var model = BsonToTournamentModel(service.InActiveCollection.Find(x => x["tournamentId"] == tournamentId).ToList()[0]);
                    model.StatusType = Status.Ended;
                    ModifyTournamentById(tournamentId, model );

                }
            }
        }

        #endregion

        #region Delete
        public static void DeleteTournamentById(string tournamentId)
        {
            using (MongoConnection service = new MongoConnection())
            {
                if(service.ActiveCollection.CountDocuments(x => x["tournamentId"] == tournamentId) != 0)
                {
                    service.ActiveCollection.FindOneAndDelete(x => x["tournamentId"] == tournamentId);
                }
                else if(service.InActiveCollection.CountDocuments(x => x["tournamentId"] == tournamentId) != 0)
                {
                    service.InActiveCollection.FindOneAndDelete(x => x["tournamentId"] == tournamentId);
                }
            }
        }
        
        
        
        #endregion
    }
}
