using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentTrackerServices.Enums;
using TournamentTrackerServices.Model;

namespace MongoDAL.Models
{
    public class TournamentModel
    {
        public string Name { get; set; }
        public string Game { get; set; }
        public TournamentTypes EliminationType { get; set; }
        public List<User> PlayerList { get; set; }
    }
}
