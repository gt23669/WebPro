using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentTrackerServices.Enums;

namespace TournamentTrackerServices.Model
{
    public class Tournament
    {
        public string Name { get; set; }
        public TournamentTypes Type { get; set; }
        public string Game { get; set; }
        public List<User> PlayerList { get; set; }
    }
}
