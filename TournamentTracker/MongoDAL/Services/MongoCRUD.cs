using MongoDAL.Interfaces;
using MongoDAL.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDAL.Services
{
    public class MongoCRUD
    {
        #region HelperMethods

        private static BsonDocument UserToBson(User user)
        {
            BsonDocument toReturn = new BsonDocument();

            return toReturn;
        }

        private 

        private static BsonDocument TournamentModelToBson(TournamentModel toChange)
        {
            BsonDocument toReturn = new BsonDocument();
            
            

            return toReturn;
        }

        private static TournamentModel BsonToTournamentModel()
        {
            throw new NotImplementedException();
        }

        #endregion
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
