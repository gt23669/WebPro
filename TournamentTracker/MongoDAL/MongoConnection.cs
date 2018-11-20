using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDAL
{
    public class MongoConnection: IDisposable
    {
        private readonly string connectionString = "mongodb://localhost:27017";
        public IMongoDatabase Database { get; set; }
        public IMongoCollection<BsonDocument> ActiveCollection { get; set; }
        public IMongoCollection<BsonDocument> InActiveCollection { get; set; }
        public MongoConnection()
        {
            var client = new MongoClient(connectionString);
            Database = client.GetDatabase(/*Database name*/ "TournamentInfo");
            ActiveCollection = Database.GetCollection<BsonDocument>(/*collection name*/"Active");
            InActiveCollection = Database.GetCollection<BsonDocument>(/*collection name*/"Inactive");
        }
        public void Dispose()
        {

        }
    }
}
