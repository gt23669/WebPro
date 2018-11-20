using MongoDAL.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentTrackerServices.Enums;
using TournamentTrackerServices.Model;

namespace MongoDAL.Services
{
    public class MongoCRUD
    {
        #region HelperMethods
        private static TournamentModel ReturnModel(BsonDocument query)
        {
            TournamentModel model = new TournamentModel()
            {
                Name = (string)query["Name"],
                Game = (string)query["Game"],
                //EliminationType = (TournamentTypes)query["Type"],
            };
            foreach (var player in query["Players"].AsBsonArray.ToList())
            {
                User person = new User()
                {
                    FirstName = (string)player[0],
                    LastName = (string)player[1],
                    Wins = (int)player[2],
                    Loses = (int)player[3]
                };
                model.PlayerList.Add(person);
            }
            return model;
        }

        #endregion
        #region Read

        public static TournamentListModel GetActiveTournament()
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

        #endregion
        #region Create
        #endregion
        #region Modify
        #endregion
        #region Delete
        #endregion
    }
}
